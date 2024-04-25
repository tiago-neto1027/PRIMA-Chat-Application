using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        // TODO enviar login para o servidor
        // TODO verificar, no lado do servidor se foi possível logar
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CloseClient();

            FormApplication formApplication = new FormApplication();
            formApplication.ShowDialog();

            this.Close();
        }
    }
}
