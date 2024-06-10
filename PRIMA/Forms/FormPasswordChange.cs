using PRIMA.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRIMA.Forms
{
    /// <summary>
    /// Represents a form for changing user passwords.
    /// </summary>
    public partial class FormPasswordChange : BaseForm
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormPasswordChange"/> class.
        /// </summary>
        /// <param name="userServiceInstance">An instance of IUserService for interacting with user-related operations.</param>

        public FormPasswordChange(IUserService userServiceInstance)
        {
            userService = userServiceInstance;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the ChangePasswordButton to change the user's password.
        /// </summary>
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if(!ValidateFields())
                return;

            string oldHashedPassword = GenerateOldHashedPassword();
            (string saltedHash, string saltString) = GenerateNewHashedPassword();

            string response = userService.ChangePass(oldHashedPassword, saltedHash, saltString);
            MessageBox.Show(response);
            if (response == "Password changed successfully!")
                this.Close();
        }

        /// <summary>
        /// Validates the fields.
        /// </summary>
        /// <returns>True if all fields are valid; otherwise, false.</returns>
        private bool ValidateFields()
        {
            string passwordPattern = @"^[a-zA-Z0-9]{8,20}$";
            string oldPassword = OldPasswordTextBox.Text;
            string newPassword = NewPasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(oldPassword) || 
                string.IsNullOrWhiteSpace(newPassword) || 
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Fill all the fields");
                return false;
            }

            if (!Regex.IsMatch(newPassword, passwordPattern))
            {
                MessageBox.Show("The password must be 8 to 20 characters long and contain only letters and numbers");
                return false;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The passwords dont match");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Generates the salted hash of the old password using the salt retrieved from the user service.
        /// </summary>
        /// <returns>The base64-encoded string representation of the old hashed password.</returns>
        private string GenerateOldHashedPassword()
        {
            string oldPassword = OldPasswordTextBox.Text;
            string oldSaltString = userService.GetSalt();

            byte[] oldSalt = Convert.FromBase64String(oldSaltString);
            byte[] oldHashedPassword = SecurityUtils.GenerateSaltedHash(oldPassword, oldSalt);

            return Convert.ToBase64String(oldHashedPassword);
        }

        /// <summary>
        /// Generates a new salted hash for the given password and returns both the salted hash and the salt string.
        /// </summary>
        /// <returns>A tuple containing the salted hash and the salt string.</returns>
        private (string saltedHash, string saltString) GenerateNewHashedPassword()
        {
            string newPassword = NewPasswordTextBox.Text;

            byte[] newSalt = SecurityUtils.GenerateSalt();
            string saltString = Convert.ToBase64String(newSalt);

            byte[] saltedHash = SecurityUtils.GenerateSaltedHash(newPassword, newSalt);
            string saltedHashString = Convert.ToBase64String(saltedHash);

            return (saltedHashString, saltString);
        }

        /// <summary>
        /// Handles the click event of the leavePasswordChangeButton to close the form.
        /// </summary>
        private void leavePasswordChangeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the KeyDown event of the ConfirmPasswordTextBox to allow pressing Enter for password change.
        /// </summary>
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
