using Microsoft.Extensions.DependencyInjection;
using PRIMA.Interfaces;
using PRIMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA
{
    public static class ServiceLocator
    {
        private static readonly ServiceProvider _serviceProvider;

        static ServiceLocator()
        {
            var services = new ServiceCollection();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddSingleton<IClient>(sp => Client.Instance);

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
