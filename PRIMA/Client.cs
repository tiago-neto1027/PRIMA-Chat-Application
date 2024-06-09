using EI.SI;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PRIMA.Interfaces;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace PRIMA
{
    /*
     * This is the Base Client class of the application
     * The class manages everything a client can and must do
     * The class is a Singleton, meaning that can only be one instance of a Client running per application.
     */
    public class Client : IClient
    {
        protected const int PORT = 4500;
        private static Client instance;
        protected NetworkStream networkStream;
        protected TcpClient tcpClient;
        protected ProtocolSI protocolSI;

        public string PublicKey {  get; private set; }
        public string PrivateKey { get; private set; }

        public byte[] SymmetricKey { get; set; }

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

        /* The following Method closes a client.
         * 
         * The method sends an EOT signal through the stream signalizing the end of transmission
         * It waits for the signal to be acknowledged by the server and then closes the stream and the client
        */
        public void Close()
        {
            byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT);
            networkStream.Write(eot, 0, eot.Length);
            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }
            networkStream.Close();
            tcpClient.Close();
        }

        /* The following methond sends a DATA packet
         * 
         * This method recieves 2 string type parameters, one with the type of the message(login, message, register...) and the other one with the data contained in it
         * 
         * The data is concatenated and sent via the stream then an ACK signal is awaited before proceeding
         * If there is any information to retrieve from the ACK signal it retrieves and returns the information
        */
        public string SendDATA(ProtocolSICmdType CmdType, string data)
        {
            byte[] packet;
            //Encrypts the data only if the cmd type is not public key, since the public key is sent in the login
            //and is needed to receive the symmetric key to encrypt everything else
            if (CmdType != ProtocolSICmdType.PUBLIC_KEY)
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

                    packet = protocolSI.Make(CmdType, Convert.ToBase64String(encryptedDataAndIv));
                }
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

        /* The following methond receives a DATA packet if it exists
         * 
         * This function simply reads the data that is available in the stream, if there is any and returns it
        */
        public string ReceiveDATA()
        {
            if (networkStream.DataAvailable)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                {
                    string receivedDATA = protocolSI.GetStringFromData();

                    byte[] combinedData;

                    combinedData = Convert.FromBase64String(receivedDATA);

                    using (Aes aes = Aes.Create())
                    {
                        combinedData = Convert.FromBase64String(receivedDATA);

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
                            receivedDATA = System.Text.Encoding.UTF8.GetString(decryptedBytes);
                        }
                    }

                    return receivedDATA;
                }
            }

            return null;
        }
    }
}
