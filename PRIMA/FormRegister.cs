using EI.SI;
using MaterialSkin.Controls;
using System;
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
        public FormRegister()
        {
            InitializeComponent();
            InitializeClient();
        }

        //The 'Login' Button simply sends the user to the login page and closes the thread.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseClient();

            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();

            this.Close();
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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //TODO Refactorize the verifications
            if (registryTBoxUserName.Text!="" && registryTBoxName.Text != "" && registryTBoxEmail.Text!="" && registryTBoxPassword.Text!="")
            {
                string pattern = @"^[a-zA-Z0-9]{8,20}$";
                if(Regex.IsMatch(registryTBoxPassword.Text, pattern))
                {
                    // TODO the password must be encrypted
                    string data = registryTBoxUserName.Text + "|" + registryTBoxName.Text + "|" + registryTBoxEmail.Text + "|" + registryTBoxPassword.Text;

                    SendDATA("register", data);

                    string response = protocolSI.GetStringFromData();
                    Array.Clear(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                    if (response == "This username is already registered.")
                    {
                        MessageBox.Show(response);
                    }
                    else
                    {
                        MessageBox.Show("User registered successfully");
                        this.Hide();
                        CloseClient();

                        FormLogin formLogin = new FormLogin();
                        formLogin.ShowDialog();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("The password must be, from 8 to 20 characters and only accepts letters and numbers");
                }
            }
            else
            {
                MessageBox.Show("There are empty fields");
            }
        }
    }
}
