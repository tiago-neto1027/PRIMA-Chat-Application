using EI.SI;
using MaterialSkin;
using MaterialSkin.Controls;
using PRIMA.Services;
using PRIMA.Interfaces;
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
using static PRIMA.MessageService;
using PRIMA.Forms;

namespace PRIMA
{
    public partial class FormApplication : BaseForm
    {
        protected readonly IMessageService messageService;
        protected readonly IClientService clientService;
        FormFactory formFactory = new FormFactory();

        bool settingsExpand;

        //This creates a dictionary to store all the chats the user has open
        Dictionary<string, List<string>> Chats = new Dictionary<string, List<string>>();
        private string selectedChat = "General";

        public FormApplication(IMessageService messageServerInstance, IClientService clientServiceInstance) : base()
        {
            InitializeComponent();
            SetComponentColors(config.Theme);

            clientService = clientServiceInstance;
            messageService = messageServerInstance;
            messageService.MessageReceived += MessageService_MessageReceived; //subscribes to an event in the MessageService
            messageService.StartReceivingMessages();

            //When initializing the app it always creates a General Chat that is the default chat of the application and selects it
            Chats.Add("General", new List<string>());
            UpdateChatsList();
            chatsListBox.SelectedIndex = 0;
        }

        // This method merely sets the component colors to the right colors depending on the theme
        private void SetComponentColors(string theme)
        {
            if (theme == "Dark")
            {
                settingsPanel.BackColor = Color.Gray;
            }
        }
        /*
         * When a message is received the vent is activated
         * 
         * The forms retrieves the arguments from the event and
         * Checks if the chat dictionary contains the chat, if it does
         * A new message is added to the chat, if it does not
         * A new chat is added with the message received
         * 
         * Finally, If the chatUsed is the same as the selected, it is updated
        */
        private void MessageService_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string chatUsed = e.Chat;
            string receivedMessage = e.Message;

            // Add the message to the dictionary in the correct chat
            if (Chats.ContainsKey(chatUsed))
            {
                Chats[chatUsed].Add(receivedMessage);
            }
            else
            {
                Chats.Add(chatUsed, new List<string>());
                Chats[chatUsed].Add(receivedMessage);
            }

            // Updates the form only if the received message is for the currently selected chat
            if (chatUsed == selectedChat)
            {
                UpdateMessagesList();
            }
        }

        // When the send button is pressed the message is sent declaring the content of the message and the chat used and the text box is cleared
        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = messageTBox.Text;
            message = message.Replace("|", "");
            string chat = selectedChat;
            messageService.SendMessage(chat, message);
            messageTBox.Clear();
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

        //Settings Menu
        private void settingsMenuTimer_Tick(object sender, EventArgs e)
        {
            if (settingsExpand)
            {
                settingsPanel.Width -= 10;
                if(settingsPanel.Width <= settingsPanel.MinimumSize.Width)
                {
                    settingsExpand = false;
                    settingsMenuTimer.Stop();
                }
            }
            else
            {
                settingsPanel.Width += 10;
                if(settingsPanel.Width >= settingsPanel.MaximumSize.Width)
                {
                    settingsExpand = true;
                    settingsMenuTimer.Stop();
                }
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsMenuTimer.Start();
        }

        //Light/Dark mode
        private void darkModeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (config.Theme=="Light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                settingsPanel.BackColor = Color.Gray;
                config.Theme = "Dark";
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                settingsPanel.BackColor = Color.White;
                config.Theme = "Light";
            }

            ConfigManager.SaveConfig(config);
            Invalidate(true);
            Update();
        }


        //This allows the user to send a message with the "Enter" key instead of pressing the button
        private void messageTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnSend_Click(sender, e);
            }
        }

        // When the application is closed it closes the client and saves the .cfg file
        private void FormApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientService.CloseClient();
            messageService.StopReceivingMessages();
            ConfigManager.SaveConfig(config);
        }

        // Changes the user Image
        private void buttonChangeImage_Click(object sender, EventArgs e)
        {

        }
        // Changes the user email

        private void buttonChangeEmail_Click(object sender, EventArgs e)
        {
            formFactory.OpenFormChangeEmail();
        }
        // Changes the user password
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            formFactory.OpenFormChangePassword();
        }
    }
}
