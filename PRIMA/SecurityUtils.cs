using System.Security.Cryptography;

namespace PRIMA
{
    /// <summary>
    /// Provides utility methods for generating salted hashes and salts.
    /// </summary>
    public static class SecurityUtils
    {
        /// <summary>
        /// Generates a salted hash for the given plain text using the specified salt.
        /// </summary>
        /// <param name="plainText">The plain text to hash.</param>
        /// <param name="salt">The salt to use in the hash generation.</param>
        /// <returns>A 32-byte array containing the salted hash.</returns>
        public static byte[] GenerateSaltedHash(string plainText, byte[] salt)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(plainText, salt, 5000))
            {
                return rfc2898.GetBytes(32);
            }
        }

        /// <summary>
        /// Generates a random salt.
        /// </summary>
        /// <returns>An 8-byte array containing the generated salt.</returns>
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
