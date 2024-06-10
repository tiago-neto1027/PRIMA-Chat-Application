using PRIMA.Forms;
using PRIMA.Interfaces;

namespace PRIMA
{
    /// <summary>
    /// Factory class to create and open different forms.
    /// </summary>
    public class FormFactory
    {
        protected readonly IUserService userServiceInstance;
        protected readonly IClientService clientServiceInstance;
        protected readonly IMessageService messageServiceInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormFactory"/> class.
        /// </summary>
        public FormFactory()
        {
            userServiceInstance = ServiceLocator.GetService<IUserService>();
            clientServiceInstance = ServiceLocator.GetService<IClientService>();
            messageServiceInstance = ServiceLocator.GetService<IMessageService>();
        }

        /// <summary>
        /// Opens the registration form.
        /// </summary>
        public void OpenFormRegister()
        {
            FormRegister formRegister = new FormRegister(userServiceInstance);
            formRegister.ShowDialog();
        }

        /// <summary>
        /// Opens the login form.
        /// </summary>
        public void OpenFormLogin()
        {
            FormLogin formLogin = new FormLogin(userServiceInstance);
            formLogin.ShowDialog();
        }

        /// <summary>
        /// Opens the main application form.
        /// </summary>
        public void OpenFormApplication()
        {
            FormApplication formApplication = new FormApplication(messageServiceInstance, clientServiceInstance, userServiceInstance);
            formApplication.ShowDialog();
        }

        /// <summary>
        /// Opens the email change form.
        /// </summary>
        public void OpenFormChangeEmail()
        {
            FormEmailChange formEmailChange = new FormEmailChange(userServiceInstance);
            formEmailChange.Show();
        }

        /// <summary>
        /// Opens the password change form.
        /// </summary>
        public void OpenFormChangePassword()
        {
            FormPasswordChange formPasswordChange = new FormPasswordChange(userServiceInstance);
            formPasswordChange.Show();
        }

    }
}
