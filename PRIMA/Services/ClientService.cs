using EI.SI;
using PRIMA.Interfaces;

namespace PRIMA.Services
{
    public class ClientService : IClientService
    {
        private readonly IClient client;

        public ClientService(IClient clientInstance)
        {
            client = clientInstance;
        }

        public void CloseClient()
        {
            client.Close();
        }
    }
}
