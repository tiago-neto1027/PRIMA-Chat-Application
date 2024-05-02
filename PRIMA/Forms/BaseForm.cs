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

        protected readonly IUserService userServiceInstance;
        protected readonly IClientService clientServiceInstance;
        protected readonly IMessageService messageServiceInstance;

        private readonly IServiceProvider serviceProvider;

        public BaseForm()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);

            // https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection
            var services = new ServiceCollection();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddSingleton<IClient>(sp => Client.Instance);

            serviceProvider = services.BuildServiceProvider();

            userServiceInstance = serviceProvider.GetRequiredService<IUserService>();
            clientServiceInstance = serviceProvider.GetRequiredService<IClientService>();
            messageServiceInstance = serviceProvider.GetRequiredService<IMessageService>();
        }

        // Factory Pattern to create the Forms
        protected void OpenFormRegister()
        {
            FormRegister formRegister = new FormRegister(userServiceInstance);
            formRegister.ShowDialog();
        }
        protected void OpenFormLogin()
        {
            FormLogin formLogin = new FormLogin(userServiceInstance);
            formLogin.ShowDialog();
        }
        protected void OpenFormApplication()
        {
            FormApplication formApplication = new FormApplication(messageServiceInstance, clientServiceInstance);
            formApplication.ShowDialog();
        }
    }
}
