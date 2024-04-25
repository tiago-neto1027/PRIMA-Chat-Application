using EI.SI;
using MaterialSkin.Controls;
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
        //Turns this text box public in order to be accessed in the other forms
        public MaterialTextBox loginTextBoxUser => loginTBoxUser;
        public FormLogin()
        {
            InitializeComponent();
            InitializeClient();
        }

        //The 'Register' Button simply sends the user to the login page and closes the thread.
        private void btnRegistry_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseClient();

            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();

            this.Close();
        }

        /*
         * This events compacts the entire data in a message from the type DATA.login and sends it to the server
         * The server treats the content and sends back an ACK signal, the ACK signal is read and, according
         * to the server response either a message is shown to the user with what must be fixed or the user is logged in
        */ 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string data = "login|" + loginTBoxUser.Text + "|" + loginTBoxPassword.Text;

            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, data);
            networkStream.Write(packet, 0, packet.Length);

            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            }

            string response = protocolSI.GetStringFromData();
            Array.Clear(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

            if(response == "The username doesn't exist!" || response == "The credentials are incorrect!")
            {
                MessageBox.Show(response);
            }
            else
            {
                this.Hide();
                CloseClient();

                FormApplication formApplication = new FormApplication();
                formApplication.ShowDialog();

                this.Close();
            }
        }
    }
}
