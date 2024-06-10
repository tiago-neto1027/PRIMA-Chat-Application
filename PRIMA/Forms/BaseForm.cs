using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;

namespace PRIMA
{
    /// <summary>
    /// Represents the base form for all other forms.
    /// Contains common functionality and configuration settings.
    /// </summary>
    public partial class BaseForm : MaterialForm
    {
        protected MaterialSkinManager materialSkinManager;
        protected Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForm"/> class.
        /// Loads the configuration and sets the theme based on the configuration.
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
            config = ConfigManager.LoadConfig();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);

            ApplyTheme();
        }

        /// <summary>
        /// Applies the theme based on the configuration
        /// </summary>
        public void ApplyTheme()
        {
            if (config.Theme == "Light")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Indigo500,
                    Primary.Indigo700,
                    Primary.Indigo100,
                    Accent.Pink200,
                    TextShade.WHITE
                    );
            }
            else if (config.Theme == "Dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.BlueGrey800,
                    Primary.BlueGrey900,
                    Primary.BlueGrey500,
                    Accent.LightBlue200,
                    TextShade.WHITE
                    );
            }
        }

        /// <summary>
        /// Checks if the specified content contains any special characters.
        /// </summary>
        /// <param name="content">The content to check.</param>
        /// <returns>True if the content contains special characters; otherwise, false.</returns>
        public bool ContainsSpecialCharacters(string content)
        {
            string pattern = "^[a-zA-Z0-9 ]*$";
            return !Regex.IsMatch(content, pattern);
        }
    }
}