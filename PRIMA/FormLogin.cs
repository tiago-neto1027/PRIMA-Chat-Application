using EI.SI;
using MaterialSkin.Controls;
using PRIMA.Services;
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
        protected readonly UserService userService;
        private readonly MessageService messageService;
        private readonly ClientService clientService;

        public FormLogin(UserService userServiceInstance, MessageService messageServiceInstance, ClientService clientServiceInstance)
        {
            InitializeComponent();
            userService = userServiceInstance;
            messageService = messageServiceInstance;
            clientService = clientServiceInstance;
        }

        /* This closes the form and opens the FormRegister */
        private void btnRegistry_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormRegister formRegister = new FormRegister(userService, messageService, clientService);
            formRegister.ShowDialog();

            this.Close();
        }

        /* Tries to Log In the User
         * If the user was Logged In, it closes the Form and opens the Application
         * If the Log In fails, it shows the user why it failed */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = loginTBoxUser.Text;
            string password = loginTBoxPassword.Text;

            string response = userService.LogInUser(username, password);

            if(response == "Success")
            {
                this.Hide();

                FormApplication formApplication = new FormApplication(messageService, clientService);
                formApplication.ShowDialog();

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
