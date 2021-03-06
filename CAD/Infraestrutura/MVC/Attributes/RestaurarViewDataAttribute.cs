using System;
using System.Web.Mvc;

namespace CAD.Infraestrutura.MVC.Attributes
{
    public class RestaurarViewDataAttribute : ActionFilterAttribute
    {
        private const string ViewDataKey = "ViewData";
        private const string RotaOrigemKey = "RotaOrigem";

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