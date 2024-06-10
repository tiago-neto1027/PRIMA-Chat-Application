using EI.SI;
using PRIMA.Interfaces;

namespace PRIMA
{
    /// <summary>
    /// The UserService class handles user-related operations by interacting with a client instance.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IClient client;

        /// <summary>
        /// Initializes a new instance of the UserService class with a specified client instance.
        /// </summary>
        /// <param name="clientInstance">The client instance to be used for communication.</param>
        public UserService(IClient clientInstance)
        {
            client = clientInstance;
        }

        /// <summary>
        /// Sends the username to the server.
        /// </summary>
        /// <param name="username">The username to send.</param>
        /// <returns>The server response.</returns>
        public string SendUsername(string username)
        {
            return client.SendDATA(ProtocolSICmdType.USER_OPTION_5, username);
        }

        /// <summary>
        /// Sends the public key to the server.
        /// </summary>
        /// <param name="publicKey">The public key to send.</param>
        /// <returns>The server response.</returns>
        public string SendPublicKey(string publicKey)
        {
            return client.SendDATA(ProtocolSICmdType.PUBLIC_KEY, publicKey);
        }

        /// <summary>
        /// Logs in the user with the provided username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The server response.</returns>
        public string LogInUser(string username, string password)
        {
            string data = username + "|" + password;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_1, data);

            return response;
        }

        /// <summary>
        /// Registers a new user with the provided information.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email address.</param>
        /// <param name="salt">The salt value.</param>
        /// <param name="saltedHash">The salted hash.</param>
        /// <returns>The server response.</returns>
        public string RegisterUser(string username, string name, string email, string salt, string saltedHash)
        {
            string data = $"{username}|{name}|{email}|{salt}|{saltedHash}";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_2, data);

            return response;
        }

        /// <summary>
        /// Changes the user's email address.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="newEmail">The new email address.</param>
        /// <returns>The server response.</returns>
        public string ChangeEmail(string password, string newEmail)
        {
            string data = password + "|" + newEmail;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_3, data);

            return response;
        }

        /// <summary>
        /// Changes the user's password.
        /// </summary>
        /// <param name="oldPasswordAttempt">The old password attempt.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="newSalt">The new salt value.</param>
        /// <returns>The server response.</returns>
        public string ChangePass(string oldPasswordAttempt, string newPassword, string newSalt)
        {
            string data = oldPasswordAttempt + "|" + newPassword + "|" + newSalt;
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_4, data);

            return response;
        }

        /// <summary>
        /// Returns the old email address.
        /// </summary>
        /// <returns>The old email address given by the server.</returns>
        public string ReturnOldMail()
        {
            string data = "OldMail";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_9, data);
            return response;
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <returns>The username given by the server.</returns>
        public string GetUsername()
        {
            string data = "Username";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_9, data);
            return response;
        }

        /// <summary>
        /// Gets the salt value.
        /// </summary>
        /// <returns>The salt given by the server.</returns>
        public string GetSalt()
        {
            string data = "Salt";
            string response = client.SendDATA(ProtocolSICmdType.USER_OPTION_9, data);
            return response;
        }
    }
}
