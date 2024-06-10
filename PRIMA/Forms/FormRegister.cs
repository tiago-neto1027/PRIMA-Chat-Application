using System;
using PRIMA.Interfaces;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PRIMA
{
    /// <summary>
    /// Handles the user registration process, including validation and interaction with the IUserService.
    /// </summary>
    public partial class FormRegister : BaseForm
    {
        protected readonly IUserService userService;
        FormFactory formFactory = new FormFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRegister"/> class.
        /// </summary>
        /// <param name="userServiceInstance">The user service instance.</param>
        public FormRegister(IUserService userServiceInstance)
        {
            InitializeComponent();
            userService = userServiceInstance;
        }

        /// <summary>
        /// Handles the login button click event to open the login form.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            formFactory.OpenFormLogin();
            this.Close();
        }

        /// <summary>
        /// Handles the register button click event to register the user.
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        private void RegisterUser()
        {
            if (!AreFieldsValid())
                return;

            string username = registryTBoxUserName.Text;
            string name = registryTBoxName.Text;
            string email = registryTBoxEmail.Text;
            string password = registryTBoxPassword.Text;

            var (saltString, saltedHashString) = GenerateSaltAndHash(password);

            string response = userService.RegisterUser(username, name, email, saltString, saltedHashString);

            HandleRegistrationResponse(response);
        }

        /// <summary>
        /// Validates the input fields.
        /// </summary>
        /// <returns>True if all fields are valid; otherwise, false.</returns>
        private bool AreFieldsValid()
        {
            return !AreFieldsEmpty() && !DoFieldsContainSpecialChars() && IsPasswordValid() && IsEmailValid();
        }

        /// <summary>
        /// Checks if the input fields are empty and shows a message if they are.
        /// </summary>
        /// <returns>True if any field is empty; otherwise, false.</returns>
        private bool AreFieldsEmpty()
        {
            if (string.IsNullOrWhiteSpace(registryTBoxUserName.Text))
            {
                MessageBox.Show("Username is empty!");
                return true;
            }
            if (string.IsNullOrWhiteSpace(registryTBoxName.Text))
            {
                MessageBox.Show("Name is empty!");
                return true;
            }
            if (string.IsNullOrWhiteSpace(registryTBoxEmail.Text))
            {
                MessageBox.Show("Email is empty!");
                return true;
            }
            if (string.IsNullOrWhiteSpace(registryTBoxPassword.Text))
            {
                MessageBox.Show("Password is empty!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the input fields contain special characters and shows a message if they do.
        /// </summary>
        /// <returns>True if any field contains special characters; otherwise, false.</returns>
        private bool DoFieldsContainSpecialChars()
        {
            if (ContainsSpecialCharacters(registryTBoxUserName.Text))
            {
                MessageBox.Show("Username can't have special characters");
                return true;
            }
            if (ContainsSpecialCharacters(registryTBoxName.Text))
            {
                MessageBox.Show("Name can't have special characters");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates the password format.
        /// </summary>
        /// <returns>True if the password format is valid; otherwise, false.</returns>
        private bool IsPasswordValid()
        {
            string passwordPattern = @"^[a-zA-Z0-9]{8,20}$";  // Password must be 8 to 20 characters long and contain only letters and numbers.

            if (!Regex.IsMatch(registryTBoxPassword.Text, passwordPattern))
            {
                MessageBox.Show("The password must be 8 to 20 characters long and contain only letters and numbers");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the email format.
        /// </summary>
        /// <returns>True if the email format is valid; otherwise, false.</returns>
        private bool IsEmailValid()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|pt)$"; // Valid email pattern.

            if (!Regex.IsMatch(registryTBoxEmail.Text, emailPattern))
            {
                MessageBox.Show("The email is not valid");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Generates the salt and salted hash for the given password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>A tuple containing the salt and salted hash as strings.</returns>
        private (string saltString, string saltedHashString) GenerateSaltAndHash(string password)
        {
            byte[] salt = SecurityUtils.GenerateSalt();
            byte[] saltedHash = SecurityUtils.GenerateSaltedHash(password, salt);

            string saltString = Convert.ToBase64String(salt);
            string saltedHashString = Convert.ToBase64String(saltedHash);

            return (saltString, saltedHashString);
        }

        /// <summary>
        /// Handles the registration response from the server.
        /// </summary>
        /// <param name="response">The response from the server.</param>
        private void HandleRegistrationResponse(string response)
        {
            if (response == "Success")
            {
                MessageBox.Show("User registered successfully");
                this.Hide();
                formFactory.OpenFormLogin();
                this.Close();
            }
            else
            {
                MessageBox.Show(response);
            }
        }

        /// <summary>
        /// Allows the user to register by pressing the "Enter" key.
        /// </summary>
        private void registryTBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnRegister_Click(sender, e);
            }
        }
    }
}
