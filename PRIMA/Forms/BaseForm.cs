using EI.SI;
using MaterialSkin.Controls;
using System;
using PRIMA.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using PRIMA.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PRIMA
{
    public partial class BaseForm : MaterialForm
    {
        protected MaterialSkinManager materialSkinManager;
        protected Config config;

        public BaseForm()
        {
            InitializeComponent();
            config = ConfigManager.LoadConfig();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);

            if (config.Theme == "Dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
        }
    }
}
