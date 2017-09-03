namespace CAD.Web.Infraestrutura.Interface
{
    public interface IConfigurationReader
    {
        string GetAppSetting(string key);
    }
}