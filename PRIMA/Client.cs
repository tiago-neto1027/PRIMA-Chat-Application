using EI.SI;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PRIMA.Interfaces;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;

namespace PRIMA
{
    /// <summary>
    /// This is the Base Client class of the application.
    /// The class manages everything a client can and must do.
    /// The class is a Singleton, meaning that there can only be one instance of a Client running per application.
    /// </summary>
    public class Client : IClient
    {
        private const int PORT = 4500;
        private static Client instance;
        private readonly NetworkStream networkStream;
        private readonly TcpClient tcpClient;
        private readonly ProtocolSI protocolSI;

        public string PublicKey {  get; private set; }
        public string PrivateKey { get; private set; }
        public byte[] SymmetricKey { get; set; }

        /// <summary>
        /// Gets the singleton instance of the Client class.
        /// </summary>
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor establishes a connection to the server, generates RSA key pairs for encryption,
        /// and initializes network streams and protocol handlers.
        /// </remarks>
        private Client()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            networkStream = tcpClient.GetStream();
            protocolSI = new ProtocolSI();

            GenerateKeys();
        }

        private void GenerateKeys()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                PublicKey = rsa.ToXmlString(false);
                PrivateKey = rsa.ToXmlString(true);
            }
        }

        /// <summary>
        /// Closes the client connection.
        /// </summary>
        public void Close()
        {
            try
            {
                byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT);
                networkStream.Write(eot, 0, eot.Length);

                while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }
            }
            finally
            {
                networkStream.Close();
                tcpClient.Close();
            }
        }

        /// <summary>
        /// Sends a DATA packet to the server.
        /// </summary>
        /// <param name="CmdType">The type of the message (e.g., login, data, register).</param>
        /// <param name="data">The data contained in the message.</param>
        /// <returns>The response received from the server.</returns>
        public string SendDATA(ProtocolSICmdType CmdType, string data)
        {
            byte[] packet;

            if (CmdType != ProtocolSICmdType.PUBLIC_KEY)
            {
                data = EncryptData(data);

                string signature = SignData(data);
                var message = new { Data = data, Signature = signature };
                string json = JsonConvert.SerializeObject(message);

                packet = protocolSI.Make(CmdType, json);
            }
            else
            {
                packet = protocolSI.Make(CmdType, data);
            }

            networkStream.Write(packet, 0, packet.Length);

            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }

            string response = protocolSI.GetStringFromData();
            Array.Clear(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

            return response;
        }

        /// <summary>
        /// Encrypts the provided data using AES encryption with the current symmetric key.
        /// </summary>
        /// <param name="data">The data to encrypt.</param>
        /// <returns>The encrypted data as a Base64-encoded string.</returns>
        private string EncryptData(string data)
        {
            byte[] iv;
            byte[] encryptedData;
            using (Aes aes = Aes.Create())
            {
                aes.Key = SymmetricKey;
                aes.GenerateIV();
                iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new System.IO.StreamWriter(cs))
                        {
                            sw.Write(data);
                        }
                        encryptedData = ms.ToArray();
                    }
                }

                byte[] encryptedDataAndIv = new byte[encryptedData.Length + iv.Length];
                Buffer.BlockCopy(encryptedData, 0, encryptedDataAndIv, 0, encryptedData.Length);
                Buffer.BlockCopy(iv, 0, encryptedDataAndIv, encryptedData.Length, iv.Length);

                return Convert.ToBase64String(encryptedDataAndIv);
            }
        }

        private string SignData(string data)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(PrivateKey);
                var encoder = new UTF8Encoding();
                byte[] dataBytes = encoder.GetBytes(data);
                byte[] signatureBytes = rsa.SignData(dataBytes, CryptoConfig.MapNameToOID("SHA256"));
                return Convert.ToBase64String(signatureBytes);
            }
        }

        /// <summary>
        /// Receives a DATA packet from the server.
        /// </summary>
        /// <returns>The received data.</returns>
        public string ReceiveDATA()
        {
            if (networkStream.DataAvailable)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                {
                    string receivedDATA = protocolSI.GetStringFromData();
                    string decryptedDATA = DecryptData(receivedDATA);

                    return decryptedDATA;
                }
            }

            return null;
        }

        /// <summary>
        /// Decrypts the provided data using AES decryption with the current symmetric key.
        /// </summary>
        /// <param name="data">The encrypted data as a Base64-encoded string.</param>
        /// <returns>The decrypted data.</returns>
        private string DecryptData(string data)
        {

            using (Aes aes = Aes.Create())
            {
                byte[] combinedData = Convert.FromBase64String(data);

                byte[] iv = new byte[aes.BlockSize / 8];
                Buffer.BlockCopy(combinedData, combinedData.Length - iv.Length, iv, 0, iv.Length);

                byte[] encryptedData = new byte[combinedData.Length - iv.Length];
                Buffer.BlockCopy(combinedData, 0, encryptedData, 0, encryptedData.Length);

                aes.Key = SymmetricKey;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedData, 0, encryptedData.Length);
                        cs.FlushFinalBlock();
                    }
                    byte[] decryptedBytes = ms.ToArray();
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}
