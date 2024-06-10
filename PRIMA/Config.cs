using System;
using System.Collections.Generic;
using System.IO;

namespace PRIMA
{
    /// <summary>
    /// Represents configuration settings.
    /// </summary>
    [Serializable]
    public class Config
    {
        public string Theme { get; set; }
    }

    /// <summary>
    /// Manages saving and loading configuration settings to and from a .cfg file.
    /// </summary>
    public static class ConfigManager
    {
        private static readonly string configFilePath = "settings.cfg";

        /// <summary>
        /// Saves the configuration settings to a .cfg file.
        /// </summary>
        /// <param name="config">The configuration settings to save.</param>
        public static void SaveConfig(Config config)
        {
            List<string> lines = new List<string>
            {
                $"Theme={config.Theme}"
            };
            File.WriteAllLines(configFilePath, lines);
        }

        /// <summary>
        /// Loads the configuration settings from a .cfg file.
        /// If the file does not exist, returns a Config object with default values.
        /// </summary>
        /// <returns>A Config object with the loaded or default settings.</returns>
        public static Config LoadConfig()
        {
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
