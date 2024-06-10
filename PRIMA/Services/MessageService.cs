using EI.SI;
using System;
using PRIMA.Interfaces;
using System.Threading;

namespace PRIMA
{
    /// <summary>
    /// Service for handling messages.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IClient client;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        private bool stopReceivingMessages;

        public MessageService(IClient clientInstance)
        {
            client = clientInstance;
        }

        /// <summary>
        /// Sends a message to the specified chat.
        /// </summary>
        /// <param name="chat">The chat identifier.</param>
        /// <param name="message">The message content.</param>
        public void SendMessage(string chat, string message) {

            string data = chat + "|" + message;
            client.SendDATA(ProtocolSICmdType.DATA, data);
        }

        /// <summary>
        /// Starts a new thread to continuously call ReceiveMessages().
        /// </summary>
        public void StartReceivingMessages()
        {
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        /// <summary>
        /// Stops the message receiving process.
        /// </summary>
        public void StopReceivingMessages()
        {
            stopReceivingMessages = true;
        }

        /// <summary>
        /// Continuously receives messages in a loop until stopped.
        /// </summary>
        private void ReceiveMessages()
        {
            while (!stopReceivingMessages)
            {
                string receivedData = client.ReceiveDATA();

                if (!string.IsNullOrEmpty(receivedData))
                {
                    string[] splitted = receivedData.Split('|');

                    if (splitted.Length == 2)
                    {
                        string chatUsed = splitted[0];
                        string message = splitted[1];
                        OnMessageReceived(chatUsed, message);
                    }
                }

                Thread.Sleep(100);
            }
        }


        /// <summary>
        /// Triggers the MessageReceived event.
        /// </summary>
        /// <param name="chat">The chat identifier.</param>
        /// <param name="message">The message content.</param>
        private void OnMessageReceived(string chat, string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(chat, message));
        }


        /// <summary>
        /// Event arguments for the MessageReceived event.
        /// </summary>
        public class MessageReceivedEventArgs : EventArgs
        {
            public string Chat { get; }
            public string Message { get; }

            public MessageReceivedEventArgs(string chat, string message)
            {
                Chat = chat;
                Message = message;
            }
        }
    }
}
