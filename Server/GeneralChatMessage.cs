﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class GeneralChatMessage
    {
        public int ID {  get; set; }
        public string Content { get; set; }
        public int SenderID { get; set; }
        public string IV { get; set; }
        public DateTime Timestamp { get; set; }

        //Parameterless Constructor (Required by EntityFramework)
        public GeneralChatMessage ()
        {

        }

        public GeneralChatMessage(string content, int senderID, string iv)
        {
            this.Content = content;
            this.SenderID = senderID;
            this.IV = iv;
            this.Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
