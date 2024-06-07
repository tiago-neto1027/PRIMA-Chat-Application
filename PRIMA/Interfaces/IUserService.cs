using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA.Interfaces
{
    public interface IUserService
    {
        string LogInUser(string username, string password);
        string RegisterUser(string username, string name, string email, string salt, string saltedHash);
        string ChangeEmail(string password, string newEmail);
        string ChangePass(string oldPasswordAttempt, string newPassword);
        string ReturnOldMail();
        string GetUsername();
    }
}
