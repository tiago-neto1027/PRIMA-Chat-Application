using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA.Interfaces
{
    public interface IClient
    {
        void Close();
        string SendDATA(ProtocolSICmdType CmdType, string data);
        string ReceiveDATA();
    }
}
