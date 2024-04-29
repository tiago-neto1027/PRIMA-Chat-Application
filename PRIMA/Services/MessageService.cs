using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRIMA
{
    public class MessageService
    {
        private readonly Client client;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public MessageService(Client clientInstance)
        {
            client = clientInstance;
        }

        public void SendMessage(string chat, string message) {

            string data = chat + "|" + message;
            client.SendDATA(ProtocolSICmdType.DATA, data);
        }

        // Starts a new thread to continuously call ReceiveMessages()
        public void StartReceivingMessages()
        {
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void ReceiveMessages()
        {
            while (true)
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


        // Triggers the MessageReceived event creating a new object with the necessary arguments and notifies the form that a message was received
        private void OnMessageReceived(string chat, string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(chat, message));
        }


        // Event class with the necessary arguments for the event
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
