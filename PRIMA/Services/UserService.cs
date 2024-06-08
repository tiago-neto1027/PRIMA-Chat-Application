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

        public void SendUsername(string username)
        {
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_5, username);
        }

        public string LogInUser(string username, string password)
        {
            string data = username + "|" + password;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_1, data);

            return response;
        }

        public string RegisterUser(string username, string name, string email, string salt, string saltedHash)
        {
            string data = $"{username}|{name}|{email}|{salt}|{saltedHash}";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_2, data);

            return response;
        }

        public string ChangeEmail(string password, string newEmail)
        {
            string data = password + "|" + newEmail;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_3, data);

            return response;
        }

        public string ChangePass(string oldPasswordAttempt, string newPassword, string newSalt)
        {
            string data = oldPasswordAttempt + "|" + newPassword + "|" + newSalt;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_4, data);

            return response;
        }
        public string ReturnOldMail()
        {
            string data = "OldMail";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_9, data);
            return response;
        }

        public string GetUsername()
        {
            string data = "Username";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_9, data);
            return response;
        }

        public string GetSalt()
        {
            string data = "Salt";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_9, data);
            return response;
        }
    }
}
