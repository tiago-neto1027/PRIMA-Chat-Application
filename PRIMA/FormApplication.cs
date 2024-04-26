using EI.SI;
using MaterialSkin;
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
        //This creates a dictionary to store all the chats the user has open
        Dictionary<string, List<string>> Chats = new Dictionary<string, List<string>>();
        private string selectedChat = "General";
        public FormApplication()
        {
            InitializeComponent();
            InitializeClient();

            //Start a separate Thread to continuosly receive messages
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();

            //When initializing the app it always creates a General Chat that is the default chat of the application and selects it
            Chats.Add("General", new List<string>());
            Chats.Add("Teste", new List<string>());
            UpdateChatsList();
            chatsListBox.SelectedIndex = 0;
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
            string data = usernameFromLogin + "|" + selectedChat + "|" + messageTBox.Text;
            messageTBox.Clear();

            SendDATA("message", data);
        }

        private void FormApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseClient();
        }

        /*
         * This event is activated whenever the user selects a chat, or changes the chat that was selected
         * 
         * When the event is activated it changes the variable that stores the chat name
        */ 
        private void chatsListBox_SelectedIndexChanged(object sender, MaterialSkin.MaterialListBoxItem selectedItem)
        {
            if(chatsListBox.SelectedItem != null)
            {
                selectedChat = selectedItem.Text;
                UpdateMessagesList();
            }
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
         * Everytime it receives a message from the server it checks the chat that was used
         * The message is then added to the usedChat message list
         * If the usedChat is the same as the selected then the message list is updated, since a new message was added
         * The thread then is put to sleep with a small delay in order to reduce cpu usage
        */ 
        private void ReceiveMessages()
        {
            while (true)
            {
                // TODO Arranjar o erro aqui
                if (networkStream.DataAvailable)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                    if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                    {
                        string receivedMessage = protocolSI.GetStringFromData();
                        string[] splited = receivedMessage.Split('|');

                        string chatUsed = splited[0];
                        receivedMessage = splited[1];

                        //Adds the message to the dictionary in the correct chat
                        if (Chats.ContainsKey(chatUsed))
                        {
                            Chats[chatUsed].Add(receivedMessage);
                        }
                        else
                        {
                            Chats.Add(chatUsed, new List<string>());
                            Chats[chatUsed].Add(receivedMessage);
                        }

                        if(chatUsed == selectedChat)
                        {
                            UpdateMessagesList();
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

        //This function updates the chats in the left list box
        private void UpdateChatsList()
        {
            chatsListBox.Items.Clear();

            foreach (var chat in Chats.Keys)
            {
                MaterialListBoxItem item = new MaterialListBoxItem(chat);
                chatsListBox.AddItem(item);
            }
        }

        //This function updates the messages in the right list box
        private void UpdateMessagesList()
        {
            messagesListBox.Items.Clear();

            if (Chats.ContainsKey(selectedChat))
            {
                foreach (var message in Chats[selectedChat])
                {
                    MaterialListBoxItem item = new MaterialListBoxItem(message);
                    messagesListBox.Items.Add(item);
                }
            }
        }
        /*
         *         private void LoadChat()
        {
            
        }
        */
    }
}
