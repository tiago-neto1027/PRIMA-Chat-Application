using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EI.SI;
using System.Threading;

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
            Console.WriteLine("SERVER READY");

            List<TcpClient> clients = new List<TcpClient>();

            while (true)
            {
                //Accepts the client connection and gets its stream
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("New application connected");

                clients.Add(client);

                ClientHandler clientHandler = new ClientHandler(client, clients);
                clientHandler.Handle();
            }
        }
    }

    class ClientHandler
    {
        private TcpClient client;
        private List<TcpClient> clients;
        
        public ClientHandler(TcpClient client, List<TcpClient> clients)
        {
            this.client = client;
            this.clients = clients;
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
                int bytesRead = networkStream.Read(protocolSI.Buffer,0, protocolSI.Buffer.Length);

                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.DATA:
                        string msg = protocolSI.GetStringFromData();
                        string[] splited = msg.Split('|');
                        string username = splited[1];

                        if (splited[0] == "login")
                        {
                            string password = splited[2];

                            using(var db = new UserContext())
                            {
                                if(!db.UsernameExists(username))
                                {
                                    byte[] ack;
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "The username doesn't exist!");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                                else
                                {
                                    var user = db.Users.First(u => u.Username == username);

                                    if(password != user.HashedPassword)
                                    {
                                        byte[] ack;
                                        ack = protocolSI.Make(ProtocolSICmdType.ACK, "The credentials are incorrect!");
                                        networkStream.Write(ack, 0, ack.Length);
                                    }
                                    else
                                    {
                                        byte[] ack;
                                        ack = protocolSI.Make(ProtocolSICmdType.ACK, "Success");
                                        networkStream.Write(ack, 0, ack.Length);
                                    }
                                }

                            }
                        }

                        if (splited[0] == "register")
                        {
                            string name = splited[2];
                            string email = splited[3];
                            string password = splited[4];
                            
                            using(var db = new UserContext())
                            {
                                if(db.UsernameExists(username))
                                {
                                    byte[] ack;
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "This username is already registered.");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                                else
                                {
                                    var user = new User(username, name, password, email);
                                    db.Users.Add(user);
                                    db.SaveChanges();

                                    byte[] ack;
                                    ack = protocolSI.Make(ProtocolSICmdType.ACK, "Success");
                                    networkStream.Write(ack, 0, ack.Length);
                                }
                            }
                        }

                        if (splited[0] == "message")
                        {
                            string chatUsed = splited[2];
                            string message = splited[3];

                            if(chatUsed == "General")
                            {
                                using (var db = new UserContext())
                                {
                                    var user = db.Users.First(u => u.Username == username);

                                    if (user != null)
                                    {
                                        var generalChatMessage = new GeneralChatMessage(message, user.ID);
                                        db.GeneralChatMessages.Add(generalChatMessage);
                                        db.SaveChanges();
                                    }
                                }
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Chat: " + chatUsed);
                            Console.WriteLine(username + ": " + message);

                            byte[] ack;
                            ack = protocolSI.Make(ProtocolSICmdType.ACK);
                            networkStream.Write(ack, 0, ack.Length);

                            message = chatUsed + "|" + username + ": " + message;
                            SendMessageToAllClients(message);
                        }
                        break;
                }
            }

            //If the signal recieved is an EOT signal, then and only then is the Thread and Client Closed
            if (protocolSI.GetCmdType() == ProtocolSICmdType.EOT)
            {
                Console.WriteLine("Ending Thread from Client");

                byte[] ack;
                ack = protocolSI.Make(ProtocolSICmdType.ACK);
                networkStream.Write(ack, 0, ack.Length);
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

            foreach (var client in clients)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
