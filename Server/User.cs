using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }

        //Parameterless Constructor (Required by EntityFramework)
        public User ()
        {

        }

        public User (string username, string name, string salt, string hashedPassword, string email)
        {
            this.Username = username;
            this.Name = name;
            this.Salt = salt;
            this.HashedPassword = hashedPassword;
            this.Email = email;
            this.DateCreated = DateTime.Now;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
