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

        //Simply verifies if a username is in the database
        public bool UsernameExists(string username)
        {
            return Users.Any(u => u.Username == username);
        }
    }
}
