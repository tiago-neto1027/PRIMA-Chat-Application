using System;
using System.Collections.Generic;
using System.IO;

namespace PRIMA
{
    [Serializable]
    public class Config
    {
        public string Theme { get; set; }
    }

    // This class uses the above to config the .cfg file
    public static class ConfigManager
    {
        private static readonly string configFilePath = "settings.cfg";

        // This method saves the .cfg File
        // Receives an object of the Config Class
        public static void SaveConfig(Config config)
        {
            List<string> lines = new List<string>
            {
                $"Theme={config.Theme}"
            };
            File.WriteAllLines(configFilePath, lines);
        }

        // This method loads the .cfg file
        // Returns a Config class object
        public static Config LoadConfig()
        {
            // If the application can't load from a file then it retrieves a Class Config with it's default values
            // This ensures that the application doesn't crash if there isn't a .cfg file
            if (!File.Exists(configFilePath))
                return new Config();

            // Generic and expandable code to read the .cfg file
            string[] lines = File.ReadAllLines(configFilePath);
            Config config = new Config();

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if(parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch(key)
                    {
                        case "Theme":
                            config.Theme = value; 
                            break;
                    }
                }
            }
            return config;
        }
    }
}
