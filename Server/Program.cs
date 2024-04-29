﻿using System;
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

            Dictionary<TcpClient, string> clients = new Dictionary<TcpClient, string>();

            while (true)
            {
                //Accepts the client connection and gets its stream
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("New application connected");

                ClientHandler clientHandler = new ClientHandler(client, clients, null);
                clientHandler.Handle();
            }
        }
    }

    class ClientHandler
    {
        private TcpClient client;
        private Dictionary<TcpClient, string> clients;
        private string username;

        public ClientHandler(TcpClient client, Dictionary<TcpClient, string> clients, string username)
        {
            this.client = client;
            this.clients = clients;
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
                string[] splited = msg.Split('|');

                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.USER_OPTION_1: //USER_OPTION_1 == Login

                        string usernameLogin = splited[0];
                        string passwordLogin = splited[1];

                        using (var db = new UserContext())
                        {
                            if (!db.UsernameExists(usernameLogin))
                            {
                                byte[] ackLogin;
                                ackLogin = protocolSI.Make(ProtocolSICmdType.ACK, "The username doesn't exist!");
                                networkStream.Write(ackLogin, 0, ackLogin.Length);
                            }
                            else
                            {
                                var user = db.Users.First(u => u.Username == usernameLogin);

                                if (passwordLogin != user.HashedPassword)
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
                        string passwordRegister = splited[3];

                        using (var db = new UserContext())
                        {
                            if (db.UsernameExists(usernameRegister))
                            {
                                byte[] ackRegister;
                                ackRegister = protocolSI.Make(ProtocolSICmdType.ACK, "This username is already registered.");
                                networkStream.Write(ackRegister, 0, ackRegister.Length);
                            }
                            else
                            {
                                var user = new User(usernameRegister, name, passwordRegister, email);
                                db.Users.Add(user);
                                db.SaveChanges();

                                byte[] ackRegister;
                                ackRegister = protocolSI.Make(ProtocolSICmdType.ACK, "Success");
                                networkStream.Write(ackRegister, 0, ackRegister.Length);
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
                                var user = db.Users.First(u => u.Username == senderUsername);

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
                        Console.WriteLine(username + ": " + message);

                        byte[] ackMessage;
                        ackMessage = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ackMessage, 0, ackMessage.Length);

                        message = chatUsed + "|" + username + ": " + message;
                        //This shouldnt send the message to all the clients, instead to just the clients that are supposed to receive it
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
