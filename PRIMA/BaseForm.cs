using EI.SI;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace PRIMA
{
    public partial class BaseForm : MaterialForm
    {
        protected MaterialSkinManager materialSkinManager;
        protected const int PORT = 4500;
        protected NetworkStream networkStream;
        protected TcpClient tcpClient;
        protected ProtocolSI protocolSI;

        public BaseForm()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
        }

        //The following method initializes a new client and connects it to the server
        protected void InitializeClient()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            networkStream = tcpClient.GetStream();
            protocolSI = new ProtocolSI();
        }

        /*
         * The following Method closes a client.
         * 
         * The method sends an EOT signal through the stream signalizing the end of transmission
         * It waits for the signal to be acknowledged by the server and then closes the stream and the client
        */
        protected void CloseClient()
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

        /*
         * This method recieves 2 string type parameters, one with the type of the message(login, message, register...) and the other one with the data contained in it
         * 
         * The data is concatenated and sent via the stream then an ACK signal is awaited before proceeding
        */ 
        protected void SendDATA(string type, string data)
        {
            data = type + "|" + data;
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, data);
            networkStream.Write(packet, 0, packet.Length);

            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }
        }
    }
}
