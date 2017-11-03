using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;

namespace splash_rss
{
    public class SplashConfig : ISplashConfig
    {
        public SplashConfig() { }

        public Dictionary<string, string> GetCommands()
        {
            Dictionary<string, string> commands = new Dictionary<string, string>();
            string[] settingsKeys = ConfigurationManager.AppSettings.AllKeys;
            foreach(string key in settingsKeys)
            {
                string value = ConfigurationManager.AppSettings[key];
                commands.Add(key, value);
            }
            return commands;
        }

        public void AddCommand(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            List<string> settingsKeys = config.AppSettings.Settings.AllKeys.ToList();
            if(!settingsKeys.Contains(key))
            {
                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Minimal);
            }
        }

        public void RemoveCommand(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            List<string> settingsKeys = config.AppSettings.Settings.AllKeys.ToList();
            if(settingsKeys.Contains(key))
            {
                config.AppSettings.Settings.Remove(key);
                config.Save(ConfigurationSaveMode.Minimal);
            }
        }
    }
}
