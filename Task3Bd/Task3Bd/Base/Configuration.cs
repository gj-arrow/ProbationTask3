using System.Configuration;

namespace Task3Bd.Base
{
    
    public class Configuration {
        private const string Url = "Url";
        private const string Username = "Username";
        private const string Password = "Password";
            
        private static string GetParameterValue(string key) {
            return ConfigurationManager.AppSettings.Get(key);
        }

        private static void SetParameterValue(string key, string value) {
            ConfigurationManager.AppSettings.Set(key, value);
        }

        public static string GetUrl() {
            return GetParameterValue(Url);
        }

        public static string GetUsername()
        {
            return GetParameterValue(Username);
        }

        public static string GetPassword()
        {
            return GetParameterValue(Password);
        }
    }
}