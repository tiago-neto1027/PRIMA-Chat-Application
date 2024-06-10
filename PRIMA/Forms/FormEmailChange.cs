using PRIMA.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRIMA.Forms
{
    public partial class FormEmailChange : BaseForm
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormEmailChange"/> class.
        /// </summary>
        /// <param name="userServiceInstance">An instance of IUserService for interacting with user-related operations.</param>
        public FormEmailChange(IUserService userServiceInstance)
        {
            userService = userServiceInstance;
            InitializeComponent();

            OldEmailBox.Text = userService.ReturnOldMail();
        }

        /// <summary>
        /// Handles the click event of the ChangeEmailButton to change the user's email.
        /// </summary>
        private void ChangeEmailButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            string newEmail = NewEmailTextBox.Text;
            string hashedPassword = GenerateHashedPassword();

            string response = userService.ChangeEmail(hashedPassword, newEmail);
            MessageBox.Show(response);

            if (response == "Email changed successfully!")
            {
                this.Close();
            }
        }

        /// <summary>
        /// Validates whether the password and new email fields are filled and if the entered email is in a valid format based on a specified email pattern.
        /// </summary>
        /// <returns>True if all conditions are met; otherwise, false.</returns>
        private bool ValidateFields()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|pt)$"; // Change the email verification parameters here
            string password = PasswordTextBox.Text;
            string newEmail = NewEmailTextBox.Text;

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("Fill all the fields");
                return false;
            }

            if (!Regex.IsMatch(newEmail, emailPattern))
            {
                MessageBox.Show("The email is not valid");
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
            string password = PasswordTextBox.Text;
            string saltString = userService.GetSalt();

            byte[] salt = Convert.FromBase64String(saltString);
            byte[] hashedPassword = SecurityUtils.GenerateSaltedHash(password, salt);

            return Convert.ToBase64String(hashedPassword);
        }

        /// <summary>
        /// Handles the click event of the leaveEmailChangeButton to close the form.
        /// </summary>
        private void leaveEmailChangeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the KeyDown event of the NewEmailTextBox to allow pressing Enter for email change.
        /// </summary>
        private void NewEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                ChangeEmailButton_Click(sender, e);
            }
        }
    }
}
