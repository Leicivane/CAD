using System.IO;
using System.Web.Mvc;

namespace CAD.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        internal const string MensagemKey = "Mensagem";

        public JsonResult SucessJson(string mensagemAlerta)
        {
            return Json(new { HasErro = false, Mensagem = mensagemAlerta }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SucessJson(object model, string mensagemAlerta = "")
        {
            return Json(new { HasErro = false, Model = model, Mensagem = mensagemAlerta }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RedirectJson(string url)
        {
            return Json(new { HasErro = false, Url = url }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FailureJson(ModelStateDictionary modelState)
        {
            return Json(modelState.ObterErrosModelState());
        }

        internal object RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}