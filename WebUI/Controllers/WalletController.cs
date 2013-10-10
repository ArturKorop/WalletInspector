using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Code.Time;

namespace WebUI.Controllers
{
    public class WalletController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Month()
        {
            return View("Month", new Month(2013, 10));
        }
    }
}
