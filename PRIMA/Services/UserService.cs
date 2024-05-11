using EI.SI;
using PRIMA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PRIMA
{
    public class UserService : IUserService
    {
        private readonly IClient client;

        public UserService(IClient clientInstance)
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

        public string ChangeEmail(string password, string newEmail)
        {
            string data = password + "|" + newEmail;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_3, data);

            return response;
        }
    }
}
