using PRIMA.Forms;
using PRIMA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIMA
{
    public class FormFactory
    {
        protected readonly IUserService userServiceInstance;
        protected readonly IClientService clientServiceInstance;
        protected readonly IMessageService messageServiceInstance;

        public FormFactory()
        {
            userServiceInstance = ServiceLocator.GetService<IUserService>();
            clientServiceInstance = ServiceLocator.GetService<IClientService>();
            messageServiceInstance = ServiceLocator.GetService<IMessageService>();
        }

        // Factory Pattern to create the Forms
        public void OpenFormRegister()
        {
            FormRegister formRegister = new FormRegister(userServiceInstance);
            formRegister.ShowDialog();
        }
        public void OpenFormLogin()
        {
            FormLogin formLogin = new FormLogin(userServiceInstance);
            formLogin.ShowDialog();
        }
        public void OpenFormApplication()
        {
            FormApplication formApplication = new FormApplication(messageServiceInstance, clientServiceInstance);
            formApplication.ShowDialog();
        }
        public void OpenFormChangeEmail()
        {
            FormEmailChange formEmailChange = new FormEmailChange(userServiceInstance);
            formEmailChange.Show();
        }
        public void OpenFormChangePassword()
        {
            FormPasswordChange formPasswordChange = new FormPasswordChange(userServiceInstance);
            formPasswordChange.Show();
        }
    }
}
