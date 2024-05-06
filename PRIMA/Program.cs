using PRIMA.Interfaces;
using PRIMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIMA
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Client clientInstance = Client.Instance;
            UserService userServiceInstance = new UserService(clientInstance);
            ClientService clientServiceInstance = new ClientService(clientInstance);

            Application.Run(new FormLogin(userServiceInstance));

            clientServiceInstance.CloseClient();
        }
    }
}
