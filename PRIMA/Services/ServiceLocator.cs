using Microsoft.Extensions.DependencyInjection;
using PRIMA.Interfaces;
using PRIMA.Services;

namespace PRIMA
{
    /// <summary>
    /// The ServiceLocator class is responsible for configuring and providing service instances using dependency injection.
    /// </summary>
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

        /// <summary>
        /// Gets the required service of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the service to retrieve.</typeparam>
        /// <returns>An instance of the requested service type.</returns>
        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
