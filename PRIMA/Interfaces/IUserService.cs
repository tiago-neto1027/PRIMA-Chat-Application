using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA.Interfaces
{
    public interface IUserService
    {
        string SendUsername(string username);
        string SendPublicKey(string publicKey);
        string LogInUser(string username, string password);
        string RegisterUser(string username, string name, string email, string salt, string saltedHash);
        string ChangeEmail(string password, string newEmail);
        string ChangePass(string oldPasswordAttempt, string newPassword, string newSalt);
        string ReturnOldMail();
        string GetUsername();
        string GetSalt();
    }
}
