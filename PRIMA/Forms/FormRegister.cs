using EI.SI;
using MaterialSkin.Controls;
using PRIMA.Services;
using System;
using PRIMA.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIMA
{
    public partial class FormRegister : BaseForm
    {
        protected readonly IUserService userService;
        FormFactory formFactory = new FormFactory();
        public FormRegister(IUserService userServiceInstance)
        {
            InitializeComponent();
            userService = userServiceInstance;
        }

        /* Sends the user back to the FormLogin */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            formFactory.OpenFormLogin();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }


        /*
         * This function verifies if all the TextBoxes have been filled
         * Then it checks if the password follows the criteria passed in the variable 'pattern' following
         * System.Text.RegularExpressions
         * 
         * If everything is according to necessary then it sends all the data to the server and awaits the ACK signal
         * Depending on the server response it either shows an error message and clears the buffer or registers the user and goes back
         * to the log in screen
        */
        private void RegisterUser()
        {            
            string passwordPattern = @"^[a-zA-Z0-9]{8,20}$";  //Change the password parameters here

            if (string.IsNullOrWhiteSpace(registryTBoxUserName.Text) ||
                string.IsNullOrWhiteSpace(registryTBoxName.Text) ||
                string.IsNullOrWhiteSpace(registryTBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(registryTBoxPassword.Text))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            if (!Regex.IsMatch(registryTBoxPassword.Text, passwordPattern))
            {
                MessageBox.Show("The password must be 8 to 20 characters long and contain only letters and numbers");
                return;
            }

            string username = registryTBoxUserName.Text;
            string name = registryTBoxName.Text;
            string email = registryTBoxEmail.Text;
            string password = registryTBoxPassword.Text;

            string response = userService.RegisterUser(username, name, email, password);

            if(response == "Success")
            {
                MessageBox.Show("User registered successfully");

                this.Hide();
                formFactory.OpenFormLogin();
                this.Close();
            }

            if (response != "Success")
            {
                MessageBox.Show(response);
            }
        }

        /* This allows the user to Register by pressing the "Enter" Key */
        private void registryTBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnRegister_Click(sender, e);
            }
        }
    }
}
