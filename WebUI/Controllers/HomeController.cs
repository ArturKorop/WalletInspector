using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Code.Common;
using Domain.Code.General;
using Domain.Interfaces;
using Microsoft.Practices.Unity;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController()
        {
            _repository = DIServiceLocator.Current.Resolve<IRepository>();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
