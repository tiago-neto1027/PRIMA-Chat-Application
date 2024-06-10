using PRIMA.Interfaces;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PRIMA
{
    /// <summary>
    /// Represents the login form of the application.
    /// </summary>
    public partial class FormLogin : BaseForm
    {
        private readonly IUserService userService;
        FormFactory formFactory = new FormFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="FormLogin"/> class.
        /// </summary>
        /// <param name="userServiceInstance">An instance of the IUserService interface.</param>
        public FormLogin(IUserService userServiceInstance)
        {
            InitializeComponent();
            userService = userServiceInstance;

            string publicKey = Client.Instance.PublicKey;
            string encryptedSymmetricKey = userService.SendPublicKey(publicKey);

            //Decrypt the symmetric key using the client's private key
            byte[] encryptedSymmetricKeyBytes = Convert.FromBase64String(encryptedSymmetricKey);
            byte[] decryptedSymmetricKeyBytes = null;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(Client.Instance.PrivateKey);
                decryptedSymmetricKeyBytes = rsa.Decrypt(encryptedSymmetricKeyBytes, RSAEncryptionPadding.Pkcs1);
            }

            //Store the symmetricKey in the Client Class
            Client.Instance.SymmetricKey = decryptedSymmetricKeyBytes;
        }

        /// <summary>
        /// Handles the Click event of the btnRegistry control.
        /// Closes the current form and opens the registration form.
        /// </summary>
        private void btnRegistry_Click(object sender, EventArgs e)
        {
            this.Hide();
            formFactory.OpenFormRegister();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// Tries to log in the user and displays appropriate messages based on the outcome.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!ValidateFields())
                return;

            string username = loginTBoxUser.Text;
            string hashedPassword = GenerateHashedPassword();

            string response = userService.LogInUser(username, hashedPassword);

            if(response == "Success")
            {
                this.Hide();
                formFactory.OpenFormApplication();
                this.Close();
            }

            if(response != "Success")
            {
                MessageBox.Show(response);
            }
        }

        /// <summary>
        /// Validates whether the password and the username fields are valid.
        /// </summary>
        /// <returns>True if all conditions are met; otherwise, false.</returns>
        private bool ValidateFields()
        {
            string username = loginTBoxUser.Text;
            string password = loginTBoxPassword.Text;

            if (ContainsSpecialCharacters(username))
            {
                MessageBox.Show("The username can't have special characters");
                return false;
            }

            if (ContainsSpecialCharacters(password))
            {
                MessageBox.Show("The password can't have special characters");
                return false;
            }

            if (userService.SendUsername(username) == "Error")
            {
                MessageBox.Show("The username doesn't exist");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Generates the salted hash of the user's password using the salt retrieved from the user service.
        /// </summary>
        /// <returns>The base64-encoded string representation of the hashed password.</returns>
        private string GenerateHashedPassword()
        {
            string password = loginTBoxPassword.Text;
            string saltString = userService.GetSalt();

            byte[] salt = Convert.FromBase64String(saltString);
            byte[] hashedPassword = SecurityUtils.GenerateSaltedHash(password, salt);

            return Convert.ToBase64String(hashedPassword);
        }

        /// <summary>
        /// Handles the KeyDown event of the loginTBoxPassword control.
        /// Allows the user to log in by pressing the "Enter" key.
        /// </summary>
        private void loginTBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnLogin_Click(sender, e);
            }
        }
    }
}
