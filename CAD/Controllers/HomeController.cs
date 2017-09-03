using System.Web.Mvc;

namespace CAD.Web.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}