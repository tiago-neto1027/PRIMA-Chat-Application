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

            if (CheckSpecialCharacters(username))
            {
                MessageBox.Show("The username can't have special characters");
                return;
            }

            if (CheckSpecialCharacters(password))
            {
                MessageBox.Show("The password can't have special characters");
                return;
            }

            string response = userService.LogInUser(username, password);

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
