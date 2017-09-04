using System.Web.Mvc;

namespace CAD.Controllers
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