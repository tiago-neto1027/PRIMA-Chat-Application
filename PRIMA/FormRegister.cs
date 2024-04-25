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

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
