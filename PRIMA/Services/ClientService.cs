using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA.Services
{
    public class ClientService
    {
        private readonly Client client;

        public ClientService(Client clientInstance)
        {
            client = clientInstance;
        }

        public void CloseClient()
        {
            client.Close();
        }
    }
}
