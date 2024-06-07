using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GeneralChatMessage> GeneralChatMessages { get; set; }


        public User FindUserByUsername(string username)
        {
            return Users.FirstOrDefault(u => u.Username == username);
        }

        public bool IfUserExists(string username)
        {
            return Users.Any(u => u.Username == username);
        }

        public bool PasswordConfirmed(User user, string password, string salt)
        {
            var hashedPassword = SecurityUtils.GenerateSaltedHash(password, Convert.FromBase64String(user.Salt));
            return user.HashedPassword == Convert.ToBase64String(hashedPassword);
        }

        public void UpdateUserEmail(string username,  string newEmail)
        {
            var user = FindUserByUsername(username);
            user.Email = newEmail;
            SaveChanges();
        }
        public void UpdateUserPassword(string username, string newPassword, string newSalt)
        {
            var user = FindUserByUsername(username);
            user.HashedPassword = newPassword;
            user.Salt = newSalt;
            SaveChanges();
        }
        public string ReturnOldEmail(User user)
        {
            if (IfUserExists(user.Username))
            {
                return user.Email;
            }
            return "not found";
        }

        public void InitializeDatabase()
        {
            // Unfortunately, before using a random query the database wasn't really being initialized
            // The code is messy just untill I find a better approach to initialize the database
            try
            {
                Users.Any(u => u.ID == 0);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
