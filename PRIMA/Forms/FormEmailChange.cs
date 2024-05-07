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
        FormFactory formFactory = new FormFactory();

        public FormEmailChange(IUserService userServiceInstance)
        {
            userService = userServiceInstance;
            InitializeComponent();
            // TODO make this work ...
            //OldEmailLabel2=
        }

        private void ChangeEmailButton_Click(object sender, EventArgs e)
        {

            string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|pt)$"; //Change the email parameters here
            string password = PasswordTextBox.Text;
            string newEmail = NewEmailTextBox.Text;

            if(string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                if (!Regex.IsMatch(newEmail, emailPattern))
                {
                    MessageBox.Show("The email is not valid");
                    return;
                }
                else
                {
                    string response = userService.ChangeEmail(password, newEmail);
                    MessageBox.Show(response);
                    if (response != "Invalid Password")
                    {
                        this.Hide();
                        
                        formFactory.RefreshFormApplication();
                        this.Close();
                    }
                }
            }
        }
    }
}
