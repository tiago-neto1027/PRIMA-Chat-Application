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
using System.Text.RegularExpressions;

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
                DarkTheme();
            }
        }
       
        public void DefaultTheme()
        {
            if(config.Theme == "Light")
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

            }

        }

        public void DarkTheme()
        {
            if(config.Theme == "Dark")
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            }

        }
        

        // Returns true if it has special characters
        public bool CheckSpecialCharacters(string content)
        {
            string pattern = "^[a-zA-Z0-9 ]*$";

            if (Regex.IsMatch(content, pattern))
                return false;
            return true;
        }
    }
}
