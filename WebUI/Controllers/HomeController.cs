using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Code.Common;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Code.Repository;
using Domain.Interfaces;
using Microsoft.Practices.Unity;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController()
        {
            _repository = DIServiceLocator.Current.Resolve<IRepository>();
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddItem(CostItem item)
        {
            item.Date = DateTime.Now;
            item.UserId = 1;
            IRepository repository = new MsSqlRepository();
            repository.Add(item);

            return View("Index");
        }

    }
}
