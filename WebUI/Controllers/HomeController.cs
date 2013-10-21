using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application for save information about you money";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Artur Korop contacts";

            return View();
        }
    }
}
