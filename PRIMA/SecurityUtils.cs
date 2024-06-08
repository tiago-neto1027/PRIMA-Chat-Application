using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA
{
    public static class SecurityUtils
    {
        public static byte[] GenerateSaltedHash(string plainText, byte[] salt)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(plainText, salt, 5000))
            {
                return rfc2898.GetBytes(32);
            }
        }

        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buff = new byte[8];
                rng.GetBytes(buff);
                return buff;
            }
        }
    }
}
