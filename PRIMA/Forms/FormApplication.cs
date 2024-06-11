using MaterialSkin;
using MaterialSkin.Controls;
using PRIMA.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PRIMA.MessageService;

namespace PRIMA
{
    /// <summary>
    /// The main application Form
    /// </summary>
    public partial class FormApplication : BaseForm
    {
        private readonly IMessageService messageService;
        private readonly IClientService clientService;
        private readonly IUserService userService;
        private readonly FormFactory formFactory = new FormFactory();

        private readonly Dictionary<string, List<string>> Chats = new Dictionary<string, List<string>>();
        private string selectedChat = "General";

        bool settingsExpand;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormApplication"/> class.
        /// Sets up the initial configuration, event handlers, and the default chat.
        /// </summary>
        public FormApplication(IMessageService messageServerInstance, IClientService clientServiceInstance, IUserService userServiceInstance) : base()
        {
            InitializeComponent();

            clientService = clientServiceInstance;
            messageService = messageServerInstance;
            userService = userServiceInstance;

            InitializeApplication();
        }

        /// <summary>
        /// Initializes the application settings, event subscriptions, chats, and username display.
        /// </summary>
        private void InitializeApplication()
        {
            SetComponentColors(config.Theme);
            SubscribeToEvents();
            InitializeChats();
            UpdateUsernameDisplay();
        }

        /// <summary>
        /// Sets the component colors based on the theme.
        /// </summary>
        private void SetComponentColors(string theme)
        {
            if (theme == "Dark")
            {
                settingsPanel.BackColor = Color.Gray;
            }
            else if (theme == "Light")
            {
                settingsPanel.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Subscribes to necessary events.
        /// </summary>
        private void SubscribeToEvents()
        {
            messageService.MessageReceived += MessageService_MessageReceived;
            messageService.StartReceivingMessages();
        }

        /// <summary>
        /// Initializes the default chats.
        /// </summary>
        private void InitializeChats()
        {
            Chats.Add("General", new List<string>());
            UpdateChatsList();
            chatsListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Updates the username display with the logged-in user's name.
        /// </summary>
        private void UpdateUsernameDisplay()
        {
            usernameDisplay.Text = "User: " + userService.GetUsername();
        }

        /// <summary>
        /// Handles the event when a message is received.
        /// Adds the message to the appropriate chat and updates the messages list if necessary.
        /// </summary>
        private void MessageService_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string chatUsed = e.Chat;
            string receivedMessage = e.Message;

            if (Chats.ContainsKey(chatUsed))
            {
                Chats[chatUsed].Add(receivedMessage);
            }
            else
            {
                Chats.Add(chatUsed, new List<string>());
                Chats[chatUsed].Add(receivedMessage);
            }

            Logger.LogsWriter(chatUsed, userService.GetUsername(), receivedMessage, selectedChat);

            if (chatUsed == selectedChat)
            {
                UpdateMessagesList();
            }
        }

        /// <summary>
        /// Handles the event when the send button is clicked.
        /// Sends the message and clears the text box.
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = messageTBox.Text.Replace("|", "");
            messageService.SendMessage(selectedChat, message);
            messageTBox.Clear();

            Logger.LogsWriter(selectedChat, userService.GetUsername(), message, userService.GetUsername());
        }

        /// <summary>
        /// Handles the event when a different chat is selected.
        /// Updates the selected chat and refreshes the messages list.
        /// </summary>
        private void chatsListBox_SelectedIndexChanged(object sender, MaterialSkin.MaterialListBoxItem selectedItem)
        {
            if(chatsListBox.SelectedItem != null)
            {
                selectedChat = selectedItem.Text;
                UpdateMessagesList();
            }
        }

        /// <summary>
        /// Updates the list of chats displayed in the chat list box.
        /// </summary>
        private void UpdateChatsList()
        {
            chatsListBox.Items.Clear();

            foreach (var chat in Chats.Keys)
            {
                chatsListBox.AddItem(new MaterialListBoxItem(chat));
            }
        }

        /// <summary>
        /// Updates the list of messages displayed in the messages list box.
        /// </summary>
        /// Why is this written this way?
        /// Windows Forms controls can only be updated from the thread that created them.
        /// 
        /// The check for InvokeRequired ensures that if the method is called from a
        /// different thread it is sent back onto the UI thread using Invoke.
        private void UpdateMessagesList()
        {
            if (messagesListBox.InvokeRequired)
            {
                messagesListBox.Invoke(new Action(UpdateMessagesList));
            }
            else
            {
                messagesListBox.Items.Clear();

                if (Chats.ContainsKey(selectedChat))
                {
                    List<string> reversedMessages = new List<string>(Chats[selectedChat]);
                    reversedMessages.Reverse();

                    foreach (var message in reversedMessages)
                    {
                        messagesListBox.Items.Add(new MaterialListBoxItem(message));
                    }
                }
            }
        }

        /// <summary>
        /// Starts the settings menu timer to toggle the settings panel.
        /// </summary>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsMenuTimer.Start();
        }

        /// <summary>
        /// Toggles the settings menu expansion.
        /// </summary>
        private void settingsMenuTimer_Tick(object sender, EventArgs e)
        {
            if (settingsExpand)
            {
                settingsPanel.Width -= 10;
                if (settingsPanel.Width <= settingsPanel.MinimumSize.Width)
                {
                    settingsExpand = false;
                    settingsMenuTimer.Stop();
                }
            }
            else
            {
                settingsPanel.Width += 10;
                if (settingsPanel.Width >= settingsPanel.MaximumSize.Width)
                {
                    settingsExpand = true;
                    settingsMenuTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Toggles between light and dark mode.
        /// </summary>
        private void darkModeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (config.Theme=="Light")
            {
                config.Theme = "Dark";
            }
            else
            {
                config.Theme = "Light";
            }

            ConfigManager.SaveConfig(config);

            SetComponentColors(config.Theme);
            ApplyTheme();

            Invalidate(true);
            Update();
        }


        /// <summary>
        /// Allows the user to send a message by pressing the "Enter" key.
        /// </summary>
        private void messageTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnSend_Click(sender, e);
            }
        }

        /// <summary>
        /// Handles the form closing event to clean up resources.
        /// </summary>
        private void FormApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientService.CloseClient();
            messageService.StopReceivingMessages();
            ConfigManager.SaveConfig(config);
        }

        /// <summary>
        /// Opens the form to change the user email.
        /// </summary>
        private void buttonChangeEmail_Click(object sender, EventArgs e)
        {
            formFactory.OpenFormChangeEmail();
        }

        /// <summary>
        /// Opens the form to change the user password.
        /// </summary>
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            formFactory.OpenFormChangePassword();
        }

        /// <summary>
        /// Closes the application on logout.
        /// </summary>
        private void optionsLogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Changes the button background color on hover.
        /// </summary>
        private void buttonChangePassword_MouseEnter(object sender, EventArgs e)
        {
            if(materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                buttonChangePassword.BackColor = Color.Gray;
            }
        }
        private void buttonChangePassword_MouseLeave(object sender, EventArgs e)
        {
            buttonChangePassword.BackColor = Color.Transparent;
        }
        private void buttonChangeEmail_MouseEnter(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                buttonChangeEmail.BackColor = Color.Gray;
            }
        }
        private void buttonChangeEmail_MouseLeave(object sender, EventArgs e)
        {
            buttonChangeEmail.BackColor = Color.Transparent;
        }
    }

    public static class Logger
    {
        public static void LogsWriter(string chat, string username, string message, string sender)
        {
            string filepath = @"..\..\..\Logs\Clients\" + username + ".txt";

            void WriteLog()
            {
                try
                {
                    using (TextWriter txtWriter = File.AppendText(filepath))
                    {
                        txtWriter.Write("\r\nLog Entry : ");
                        txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                        txtWriter.WriteLine("  :",chat,sender);
                        txtWriter.WriteLine("  :{0}", message);
                        txtWriter.WriteLine("-------------------------------");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log the error, show a message, etc.)
                    Console.WriteLine("An error occurred while writing to the log file: " + ex.Message);
                }
            }

            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));

            // Write log (File.AppendText creates the file if it doesn't exist)
            WriteLog();
        }
    }
}