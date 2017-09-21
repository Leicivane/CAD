using CAD.Models;
using System;
using System.Web.Mvc;

namespace CAD.Controllers
{
    public class FuncionarioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(NovoFuncionarioVM model)
        {
            if (!ModelState.IsValid) return View();

            throw new NotImplementedException();
        }
    }
}