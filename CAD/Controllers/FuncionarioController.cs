using CAD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Newtonsoft.Json;

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


    public static class ModelStateHelper
    {
        public static object ObterErrosModelState(this ModelStateDictionary modelState)
        {
            var chaves = from modelstate in modelState.AsQueryable().Where(f => f.Value.Errors.Count > 0)
                         select modelstate.Key;
            var listaErros = from modelstate in modelState.AsQueryable().Where(f => f.Value.Errors.Count > 0)
                             select modelstate.Value.Errors.FirstOrDefault(a => !string.IsNullOrEmpty(a.ErrorMessage));

            listaErros = listaErros.Where(e => e != null);
            var resultado = new { HasErro = listaErros.Any(), chaves = chaves.ToList(), listaErros = listaErros.Select(a => a.ErrorMessage).ToList() };

            return resultado;
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
        public ActionResult Novo(NovoFuncionarioVM model, IEnumerable<string> horarioDeContato, IEnumerable<string> numero, IEnumerable<string> ddd)
        {
            if (!ModelState.IsValid) return View();

            var dto = NovoFuncionarioVM.Converter(model, horarioDeContato, numero, ddd);
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult TelefoneJson()
        {
            var view = RenderRazorViewToString("_Telefones", new[] { new TelefoneVM() });
            return SucessJson(view);
        }
    }
}