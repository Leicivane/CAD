using System.Configuration;
using CAD.Infraestrutura.Interface;

namespace CAD.Infraestrutura.MVC
{
    public class ConfigurationReader : IConfigurationReader
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}