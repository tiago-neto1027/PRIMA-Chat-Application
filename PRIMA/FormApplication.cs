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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIMA
{
    public partial class FormApplication : BaseForm
    {
        public FormApplication()
        {
            InitializeComponent();
            InitializeClient();
        }

        /*
         * The following event happens when the user clicks on the "Send" Button
         * 
         * Everytime the event is triggered the username is fetched from the Login form previously filled
         * A message is created in the following format: 'type|username|message'
         * Then the message is written to the stream and awaits the ack signal from the server before moving on
        */ 
        private void btnSend_Click(object sender, EventArgs e)
        {
            string usernameFromLogin = ((FormLogin)Application.OpenForms["FormLogin"]).loginTextBoxUser.Text;
            string data = usernameFromLogin + "|" + messageTBox.Text;
            messageTBox.Clear();

            SendDATA("message", data);
        }

        private void FormApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseClient();
        }

        //This allows the user to send a message with the "Enter" key instead of pressing the button
        private void messageTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnSend_Click(sender, e);
            }
        }
    }
}
