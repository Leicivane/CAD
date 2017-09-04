namespace CAD.Infraestrutura.Interface
{
    public interface IConfigurationReader
    {
        string GetAppSetting(string key);
    }
}