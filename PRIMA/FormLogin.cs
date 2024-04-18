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
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();

            this.Close();
        }

        // TODO enviar login para o servidor
        // TODO verificar, no lado do servidor se foi possível logar
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormApplication formApplication = new FormApplication();
            formApplication.ShowDialog();

            this.Close();
        }
    }
}
