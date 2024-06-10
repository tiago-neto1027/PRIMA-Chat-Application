using EI.SI;
using MaterialSkin.Controls;
using PRIMA.Services;
using PRIMA.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PRIMA
{
    public partial class FormLogin : BaseForm
    {
        private readonly IUserService userService;
        FormFactory formFactory = new FormFactory();

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

        /* This closes the form and opens the FormRegister */
        private void btnRegistry_Click(object sender, EventArgs e)
        {
            this.Hide();
            formFactory.OpenFormRegister();
            this.Close();
        }

        /* Tries to Log In the User
         * If the user was Logged In, it closes the Form and opens the Application
         * If the Log In fails, it shows the user why it failed */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = loginTBoxUser.Text;
            string password = loginTBoxPassword.Text;

            if (ContainsSpecialCharacters(username))
            {
                MessageBox.Show("The username can't have special characters");
                return;
            }

            if (ContainsSpecialCharacters(password))
            {
                MessageBox.Show("The password can't have special characters");
                return;
            }

            if(userService.SendUsername(username) == "Error")
            {
                MessageBox.Show("The username doesn't exist");
                return;
            }

            string saltString = userService.GetSalt();
            byte[] salt = Convert.FromBase64String(saltString);

            byte[] hashedPassword = SecurityUtils.GenerateSaltedHash(password, salt);
            string hashedPasswordString = Convert.ToBase64String(hashedPassword);

            string response = userService.LogInUser(username, hashedPasswordString);

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
        
        /* This allows the user to log in by pressing the "Enter" Key */
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
