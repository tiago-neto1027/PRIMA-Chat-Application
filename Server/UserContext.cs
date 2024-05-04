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


        //Simply verifies if a username is in the database
        public bool UsernameExists(string username)
        {
            return Users.Any(u => u.Username == username);
        }
        public void InitializeDatabase()
        {
            Database.Connection.Open();

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
