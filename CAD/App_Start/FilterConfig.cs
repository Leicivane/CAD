using System.Web.Mvc;
using CAD.Infraestrutura.MVC.Attributes;

namespace CAD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new GlobalErrorHandlerAttribute());
            filters.Add(new RestaurarViewDataAttribute());
        }
    }
}