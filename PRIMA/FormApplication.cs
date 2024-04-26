using EI.SI;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIMA
{
    public partial class FormApplication : BaseForm
    {
        public FormApplication()
        {
            InitializeComponent();
            InitializeClient();

            //Start a separate Thread to continuosly receive messages
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        /*
         * The following event happens when the user clicks on the "Send" Button
         * 
         * Everytime the event is triggered the username is fetched from the Login form previously filled
         * A message is created in the following format: 'type|username|message'
         * Then the message is written to the stream and awaits the ack signal from the server before moving on
        */ 
        private void btnSend_Click(object sender, EventArgs e)
        {
            string usernameFromLogin = ((FormLogin)Application.OpenForms["FormLogin"]).loginTextBoxUser.Text;
            string data = usernameFromLogin + "|" + messageTBox.Text;
            messageTBox.Clear();

            SendDATA("message", data);
        }

        private void FormApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseClient();
        }

        //This allows the user to send a message with the "Enter" key instead of pressing the button
        private void messageTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnSend_Click(sender, e);
            }
        }

        /*
         * This function is a background thread that continuosly listens to the server for messages
         * Everytime it receives a message from the server the message is displayed on the screen
         * The thread then is put to sleep with a small delay in order to reduce cpu usage
        */ 
        private void ReceiveMessages()
        {
            while (true)
            {
                if (networkStream.DataAvailable)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                    if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                    {
                        string receivedMessage = protocolSI.GetStringFromData();

                        ChatListBox.AddItem(receivedMessage);
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
