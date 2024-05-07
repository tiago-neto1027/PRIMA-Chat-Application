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

        public void UpdateUserProfilePic(string username, byte[] newProfilePic)
        {
            var user = Users.FirstOrDefault(u => u.Username == username);
            user.ProfilePic = newProfilePic;
            SaveChanges();
        }

        public bool PasswordConfirmed(User user,string password)
        {
            if(user.HashedPassword == password)
            {
                return true;
            }
            return false;
        }

        public void UpdateUserEmail(string username,  string newemail)
        {
            var user = FindUserByUsername(username);
            user.Email = newemail;
            SaveChanges();
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

            }
        }
    }
}
