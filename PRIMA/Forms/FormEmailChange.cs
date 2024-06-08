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

namespace PRIMA.Forms
{
    public partial class FormEmailChange : BaseForm
    {
        private readonly IUserService userService;

        public FormEmailChange(IUserService userServiceInstance)
        {
            userService = userServiceInstance;
            InitializeComponent();

            OldEmailBox.Text = userService.ReturnOldMail();
        }

        /*
         * The following event happens when the Form Button is Pressed
         * 
         * When it is, we check if all the fields are filled and then if the email is a valid email
         * If all that checks out the data is then sent by the UserService to the server and it's checked
         * with the user credentials, if they are correct the email is then changed
        */
        private void ChangeEmailButton_Click(object sender, EventArgs e)
        {

            string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|pt)$"; //Change the email verification parameters here
            string password = SecurityUtils.HashPassword(PasswordTextBox.Text);
            string newEmail = NewEmailTextBox.Text;

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("Fill all the fields");
                return;
            }

            if (!Regex.IsMatch(newEmail, emailPattern))
            {
                MessageBox.Show("The email is not valid");
                return;
            }
            else
            {
                string response = userService.ChangeEmail(password, newEmail);
                MessageBox.Show(response);
                if (response == "Email changed successfully!")
                {
                    this.Close();
                }
            }
        }

        private void leaveEmailChangeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
