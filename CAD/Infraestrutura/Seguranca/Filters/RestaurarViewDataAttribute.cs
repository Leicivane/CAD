using System;
using System.Web.Mvc;

namespace CAD.Web.Infraestrutura.Seguranca.Filters
{
    public class RestaurarViewDataAttribute : ActionFilterAttribute
    {
        private readonly string ViewDataKey = "ViewData";
        private readonly string RotaOrigemKey = "RotaOrigem";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var tempData = filterContext.Controller.TempData;

            var rotaAtual =
                $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}/{filterContext.ActionDescriptor.ActionName}";

            var possuiViewData = tempData.ContainsKey(ViewDataKey);
            var ehActionDeRetorno = string.Compare(rotaAtual, (string)tempData[RotaOrigemKey], StringComparison.OrdinalIgnoreCase);

            if (possuiViewData && ehActionDeRetorno == 0)
            {
                filterContext.Controller.ViewData = (ViewDataDictionary)tempData[ViewDataKey];
            }
        }
    }
}