using EI.SI;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA
{
    /*
     * This is the Base Client class of the application
     * The class manages everything a client can and must do
     * The class is a Singleton, meaning that can only be one instance of a Client running per application.
     */
    public class Client
    {
        protected const int PORT = 4500;
        private static Client instance;
        protected NetworkStream networkStream;
        protected TcpClient tcpClient;
        protected ProtocolSI protocolSI;

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

        //Initializes the Client class connecting it to the server
        private Client()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            networkStream = tcpClient.GetStream();
            protocolSI = new ProtocolSI();
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
            byte[] packet = protocolSI.Make(CmdType, data);
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
                    return receivedDATA;
                }
            }

            return null;
        }
    }
}
