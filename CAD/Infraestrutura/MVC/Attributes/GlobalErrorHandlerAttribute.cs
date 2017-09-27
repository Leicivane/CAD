using System.Web.Configuration;
using CAD.Core.Negocio.Exceptions;
using CAD.Infraestrutura.Extensions;
using System.Web.Mvc;
using System.Web.Routing;

namespace CAD.Infraestrutura.MVC.Attributes
{
    public class GlobalErrorHandlerAttribute : HandleErrorAttribute
    {
        private const string ViewDataKey = "ViewData";
        private const string RotaOrigemKey = "RotaOrigem";

        public override void OnException(ExceptionContext filterContext)
        {
            var excecao = filterContext.Exception;

            if (excecao is NegocioException)
            {
                TratarErrosNegocio(excecao as NegocioException, filterContext);

                TratarApresentacao(filterContext);
            }
            else
            {
                filterContext.ExceptionHandled = false;
            }
        }

        #region Tratamento Apresentacao

        private void TratarApresentacao(ExceptionContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var rotaOrigem = request.UrlReferrer == null ? GetRotaPadrao() : request.UrlReferrer.GetRouteData();

            filterContext.HttpContext.Response.Clear();

            filterContext.Controller.TempData[ViewDataKey] = filterContext.Controller.ViewData;
            filterContext.Controller.TempData[RotaOrigemKey] = $"{rotaOrigem["controller"]}/{rotaOrigem["action"]}";

            filterContext.Result = new RedirectToRouteResult(rotaOrigem);
        }

        private RouteValueDictionary GetRotaPadrao()
        {
            
            return new RouteValueDictionary(new
            {
                controller = "Conta",
                action = "Login"
            });
        }

        #endregion

        # region Tratamento Negocio

        private static void TratarErrosNegocio(NegocioException excecao, ExceptionContext contexto)
        {
            AddErro(excecao.Message, contexto);

            contexto.ExceptionHandled = true;
        }


        private static void AddErro(string mensagem, ExceptionContext contexto)
        {
            contexto.Controller.ViewData.ModelState.AddModelError(string.Empty, mensagem);
        }

        #endregion
    }
}