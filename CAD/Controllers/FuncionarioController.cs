using CAD.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace CAD.Controllers
{
    public class BaseController : Controller
    {
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
    public class FuncionarioController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View("Editor");
        }

        [HttpPost]
        public ActionResult Novo(NovoFuncionarioVM model)
        {
            if (!ModelState.IsValid) return View();

            var dto = NovoFuncionarioVM.Converter(model);
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult TelefoneJson()
        {
            var view = RenderRazorViewToString("_Telefones", new[] { new TelefoneVM() });
            return SucessJson(view);
        }
    }
}