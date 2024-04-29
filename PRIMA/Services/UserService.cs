using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA
{
    public class UserService
    {
        private readonly Client client;

        public UserService(Client clientInstance)
        {
            client = clientInstance;
        }

        public string LogInUser(string username, string password)
        {
            string data = username + "|" + password;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_1, data);

            return response;
        }

        public string RegisterUser(string username, string name, string email, string password)
        {
            // TODO: Implement password encryption
            string data = $"{username}|{name}|{email}|{password}";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_2, data);

            return response;
        }
    }
}
