using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PRIMA.MessageService;

namespace PRIMA.Interfaces
{
    public interface IMessageService
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
        void SendMessage(string chat, string message);
        void StartReceivingMessages();
    }
}
