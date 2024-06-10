using PRIMA.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PRIMA.Forms
{
    public partial class FormPasswordChange : BaseForm
    {
        private readonly IUserService userService;

        public FormPasswordChange(IUserService userServiceInstance)
        {
            userService = userServiceInstance;
            InitializeComponent();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            string passwordPattern = @"^[a-zA-Z0-9]{8,20}$";

            string oldPassword = OldPasswordTextBox.Text;
            string newPassword = NewPasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) 
                || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Fill all the fields");
                return;
            }

            if (!Regex.IsMatch(newPassword, passwordPattern))
            {
                MessageBox.Show("The password must be 8 to 20 characters long and contain only letters and numbers");
                return;
            }
            
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The passwords dont match");
                return;
            }

            //Generates the old password hash to send to the server and confirm the passwords

            string oldSaltString = userService.GetSalt();
            byte[] oldSalt = Convert.FromBase64String(oldSaltString);

            byte[] oldHashedPassword = SecurityUtils.GenerateSaltedHash(oldPassword, oldSalt);
            string oldHashedPasswordString = Convert.ToBase64String(oldHashedPassword);

            //Generates the new salt and hashes the new password
            byte[] newSalt = SecurityUtils.GenerateSalt();
            byte[] saltedHash = SecurityUtils.GenerateSaltedHash(newPassword, newSalt);

            string saltString = Convert.ToBase64String(newSalt);
            string saltedHashString = Convert.ToBase64String(saltedHash);

            string response = userService.ChangePass(oldHashedPasswordString, saltedHashString, saltString);
            MessageBox.Show(response);
            if (response == "Password changed successfully!")
                this.Close();
        }

        private void leavePasswordChangeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                ChangePasswordButton_Click(sender, e);
            }
        }
    }
}
