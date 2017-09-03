using CAD.Web.Infraestrutura.Interface;
using System.Configuration;

namespace CAD.Web.Controllers
{
    public class ConfigurationReader : IConfigurationReader
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}