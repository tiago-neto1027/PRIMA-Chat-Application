using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EI.SI;
using System.Threading;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Security.Cryptography;
using System.IO;

namespace Server
{
    internal class Program
    {
        private const int PORT = 4500;
        static void Main(string[] args)
        {
            //Creates the server and starts listening
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
            TcpListener listener = new TcpListener(endPoint);

            listener.Start();

            // This simply opens the database when the server is started
            // The database is initializer here so that the user experiences less or none waiting time
            // when performing the first action using the database
            using (var db = new UserContext())
            {
                db.InitializeDatabase();
            }
            Console.WriteLine("Database open");
            Console.WriteLine("SERVER READY");

            Dictionary<TcpClient, string> clients = new Dictionary<TcpClient, string>();
            Dictionary<TcpClient, string> clientPublicKeys = new Dictionary<TcpClient, string>();
            Dictionary<TcpClient, byte[]> clientSymmetricKeys = new Dictionary<TcpClient, byte[]>();

            while (true)
            {
                //Accepts the client connection and gets its stream
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("New application connected");

                ClientHandler clientHandler = new ClientHandler(client, clients, clientPublicKeys, clientSymmetricKeys ,null);
                clientHandler.Handle();
            }
        }
    }

    class ClientHandler
    {
        private TcpClient client;
        private Dictionary<TcpClient, string> clients;
        private Dictionary<TcpClient, string> clientPublicKeys;
        private Dictionary<TcpClient, byte[]> clientSymmetricKeys;
        private string username;

        public ClientHandler(
            TcpClient client,
            Dictionary<TcpClient, string> clients,
            Dictionary<TcpClient, string> clientPublicKeys,
            Dictionary<TcpClient, byte[]> clientSymmetricKeys,
            string username)
        {
            this.client = client;
            this.clients = clients;
            this.clientPublicKeys = clientPublicKeys;
            this.clientSymmetricKeys = clientSymmetricKeys;
            this.username = username;
        }

        public void Handle()
        {
            Thread thread = new Thread(threadHandler);
            thread.Start();
        }

        /* 
         * Inside this function we handle the packets recieved by the server
         * While handling, at the end of each packet we always send an ACK package so the client application knows the server handled it
         * First we check if the signal recieved is an EOT sign, marking the end of transmission,
         * If the signal recieved is not an EOT we check it's type and act accordingly
         * 
         * If it's the type DATA we handle according to it's type
         * The DATA recieved here always comes with a type through the stream that is used to check the type of the message
         * If the message is from the login type we then proceed to verify the user's information and log the user in
         * If the message is from the message type we then proceed to send the message to whoever it may concern
         * If the message is from the register type, we check if the username already exists, if not it registers, if it already exists a message is sent to the client
         * 
        */
        private void threadHandler()
        {
            NetworkStream networkStream = client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();

            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                string msg = protocolSI.GetStringFromData();

                if (protocolSI.GetCmdType() != ProtocolSICmdType.PUBLIC_KEY)
                {
                    byte[] combinedData;

                    try
                    {
                        combinedData = Convert.FromBase64String(msg);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Base64 string");
                        return;
                    }

                    if (combinedData.Length < 16)
                    {
                        Console.WriteLine("Invalid data length");
                        return;
                    }

                    using (Aes aes = Aes.Create())
                    {
                        combinedData = Convert.FromBase64String(msg);

                        // Extract the IV (the first 16 bytes)
                        byte[] iv = new byte[aes.BlockSize / 8]; // AES block size is 16 bytes (128 bits)
                        Buffer.BlockCopy(combinedData, combinedData.Length - iv.Length, iv, 0, iv.Length);

                        // Extract the encrypted data (the remaining bytes)
                        byte[] encryptedData = new byte[combinedData.Length - iv.Length];
                        Buffer.BlockCopy(combinedData, 0, encryptedData, 0, encryptedData.Length);

                        aes.Key = clientSymmetricKeys[client];
                        aes.IV = iv;

                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                            {
                                cs.Write(encryptedData, 0, encryptedData.Length);
                                cs.FlushFinalBlock(); // Ensure all data is written to the stream
                            }
                            byte[] decryptedBytes = ms.ToArray();
                            msg = System.Text.Encoding.UTF8.GetString(decryptedBytes); // Convert bytes to string
                        }
                    }
                }

                string[] splited = msg.Split('|');

                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.PUBLIC_KEY:
                        string publicKey = splited[0];
                        clientPublicKeys[client] = publicKey;

                        using (Aes aes = Aes.Create())
                        {
                            aes.GenerateKey();
                            clientSymmetricKeys[client] = aes.Key;
                        }

                        using (RSA rsa = RSA.Create())
                        {
                            rsa.FromXmlString(publicKey);
                            byte[] encryptedSymmetricKey = rsa.Encrypt(clientSymmetricKeys[client], RSAEncryptionPadding.Pkcs1);

                            byte[] ackPublicKey = protocolSI.Make(ProtocolSICmdType.ACK, Convert.ToBase64String(encryptedSymmetricKey));
                            networkStream.Write(ackPublicKey, 0, ackPublicKey.Length);
                        }

                        break;

                    case ProtocolSICmdType.USER_OPTION_1: //USER_OPTION_1 == Login

                        string usernameLogin = splited[0];
                        string passwordLogin = splited[1];

                        using (var db = new UserContext())
                        {
                            if (!db.IfUserExists(usernameLogin))
                            {
                                byte[] ackLogin;
                                ackLogin = protocolSI.Make(ProtocolSICmdType.ACK, "The username doesn't exist!");
                                networkStream.Write(ackLogin, 0, ackLogin.Length);
                            }
                            else
                            {
                                var user = db.Users.First(u => u.Username == usernameLogin);

                                if (!db.PasswordConfirmed(user, passwordLogin))
                                {
                                    byte[] ackLogin;
                                    ackLogin = protocolSI.Make(ProtocolSICmdType.ACK, "The credentials are incorrect!");
                                    networkStream.Write(ackLogin, 0, ackLogin.Length);
                                }
                                else
                                {
                                    this.username = usernameLogin;
                                    clients[client] = usernameLogin;

                                    byte[] ackLogin;
                                    ackLogin = protocolSI.Make(ProtocolSICmdType.ACK, "Success");
                                    networkStream.Write(ackLogin, 0, ackLogin.Length);
                                }
                            }
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_2: //USER_OPTION_2 == Register

                        string usernameRegister = splited[0];
                        string name = splited[1];
                        string email = splited[2];
                        string saltRegister = splited[3];
                        string passwordRegister = splited[4];

                        using (var db = new UserContext())
                        {
                            if (db.IfUserExists(usernameRegister))
                            {
                                byte[] ackRegister;
                                ackRegister = protocolSI.Make(ProtocolSICmdType.ACK, "This username is already registered.");
                                networkStream.Write(ackRegister, 0, ackRegister.Length);
                            }
                            else
                            {
                                var user = new User(usernameRegister, name, saltRegister, passwordRegister, email);
                                db.Users.Add(user);
                                db.SaveChanges();

                                byte[] ackRegister;
                                ackRegister = protocolSI.Make(ProtocolSICmdType.ACK, "Success");
                                networkStream.Write(ackRegister, 0, ackRegister.Length);
                            }
                        }

                        break;

                    case ProtocolSICmdType.USER_OPTION_3: //USER_OPTION_3 == Change Email
                        
                        string password = splited[0];
                        string newEmail = splited[1];
                        string username = clients[client];


                        using (var db = new UserContext())
                        {

                            if (db.IfUserExists(username))
                            {
                                var user = db.FindUserByUsername(username);
                                byte[] ack;
                                if (db.PasswordConfirmed(user, password))
                                {
                                    db.UpdateUserEmail(username, newEmail);
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "Email changed successfully!");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                                else
                                {
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "Invalid Password!");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                            }
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_4: //USER_OPTION_4 == Change Password

                        string oldPasswordAttempt = splited[0];
                        string newPassword = splited[1];
                        string newSalt = splited[2];
                        string currentUsername = clients[client];

                        using (var db = new UserContext())
                        {
                            if (db.IfUserExists(currentUsername))
                            {
                                var user = db.FindUserByUsername(currentUsername);
                                byte[] ack;
                                if(db.PasswordConfirmed(user, oldPasswordAttempt))
                                {
                                    db.UpdateUserPassword(currentUsername, newPassword, newSalt);
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "Password changed successfully!");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                                else
                                {
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "Invalid Password!");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                            }
                        }
                        break;

                    case ProtocolSICmdType.USER_OPTION_5: //USER_OPTION_5 == RECEIVES THE CLIENT USERNAME

                        string updateUsername = splited[0];

                        using (var db = new UserContext())
                        {
                            if (db.IfUserExists(updateUsername))
                            {
                                this.username = updateUsername;
                                clients[client] = updateUsername;
                                byte[] ackUpdateUsername = protocolSI.Make(ProtocolSICmdType.ACK);
                                networkStream.Write(ackUpdateUsername, 0, ackUpdateUsername.Length);
                            }
                            else
                            {
                                byte[] ackUpdateUsername = protocolSI.Make(ProtocolSICmdType.ACK, "Error");
                                networkStream.Write(ackUpdateUsername, 0, ackUpdateUsername.Length);
                            }
                        }

                        break;

                    case ProtocolSICmdType.USER_OPTION_9: //USER_OPTION_9 == GET INFO
                        string type = splited[0];
                        string usernam = clients[client];
                        using (var db = new UserContext())
                        {
                            if (db.IfUserExists(usernam))
                            {
                                var user = db.FindUserByUsername(usernam);
                                byte[] ack;
                                switch (type)
                                {
                                    case "OldMail":
                                        ack = protocolSI.Make(ProtocolSICmdType.ACK, user.Email);
                                        networkStream.Write(ack, 0, ack.Length);
                                        break;
                                    case "Username":
                                        ack = protocolSI.Make(ProtocolSICmdType.ACK, usernam);
                                        networkStream.Write(ack, 0, ack.Length);
                                        break;
                                    case "Salt":
                                        ack = protocolSI.Make(ProtocolSICmdType.ACK, user.Salt);
                                        networkStream.Write(ack, 0, ack.Length);
                                        break;
                                }
                            }
                        }
                        break;


                    case ProtocolSICmdType.DATA:

                        string chatUsed = splited[0];
                        string message = splited[1];
                        string senderUsername = clients[client];

                        if (chatUsed == "General")
                        {
                            using (var db = new UserContext())
                            {
                                var user = db.FindUserByUsername(senderUsername);

                                if(user != null)
                                {
                                    var generalChatMessage = new GeneralChatMessage(message, user.ID);
                                    db.GeneralChatMessages.Add(generalChatMessage);
                                    db.SaveChanges();
                                }
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Chat: " + chatUsed);
                        Console.WriteLine(senderUsername + ": " + message);

                        byte[] ackMessage;
                        ackMessage = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ackMessage, 0, ackMessage.Length);

                        message = chatUsed + "|" + senderUsername + ": " + message;
                        // TODO: This shouldnt send the message to all the clients, instead to just the clients that are supposed to receive it
                        SendMessageToAllClients(message);

                        break;
                }
            }

            //If the signal recieved is an EOT signal, then and only then is the Thread and Client Closed
            if (protocolSI.GetCmdType() == ProtocolSICmdType.EOT)
            {
                Console.WriteLine("Ending Thread from Client");

                byte[] ackEOT;
                ackEOT = protocolSI.Make(ProtocolSICmdType.ACK);
                networkStream.Write(ackEOT, 0, ackEOT.Length);
                networkStream.Close();
                clients.Remove(client);
                client.Close();
            }
        }

        //This functions sends the message received to all the clients connected to the database
        private void SendMessageToAllClients(string message)
        {
            ProtocolSI protocolSI = new ProtocolSI();
            byte[] data = protocolSI.Make(ProtocolSICmdType.DATA, message);

            foreach (var entry in clients)
            {
                TcpClient client = entry.Key;
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
