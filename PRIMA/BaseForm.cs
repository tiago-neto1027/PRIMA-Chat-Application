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

namespace PRIMA
{
    public partial class BaseForm : MaterialForm
    {
        protected const int PORT = 4500;
        protected NetworkStream networkStream;
        protected TcpClient tcpClient;
        protected ProtocolSI protocolSI;

        //Initializes a new client and connects it to the server
        protected void InitializeClient()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            networkStream = tcpClient.GetStream();
            protocolSI = new ProtocolSI();
        }

        /*
         * The following Function closes a client.
         * 
         * The function sends an EOT signal through the stream signalizing the end of transmission
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
    }
}
