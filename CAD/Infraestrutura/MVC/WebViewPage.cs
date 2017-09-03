using CAD.Web.Infraestrutura.Interface;
using System.Web.Mvc;
using CAD.Web.Controllers;

namespace CAD.Web.Infraestrutura.MVC
{
    public abstract class CADWebViewPage<TModel> : WebViewPage<TModel>
    {
        private readonly IConfigurationReader _reader;

        /// <summary>
        /// Retorna o nome da aplicação
        /// </summary>
        public string AppName { get; set; }
        protected CADWebViewPage():this(new ConfigurationReader())
        {
        }

        protected CADWebViewPage(IConfigurationReader reader)
        {
            _reader = reader;
        }

        public override void InitHelpers()
        {
            const string appName = "appName";
            AppName = _reader.GetAppSetting(appName);
        }

    }
}