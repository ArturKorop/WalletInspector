using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Code.Repository;
using Domain.Interfaces;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repository = new MsSqlRepository();
            var temp = repository.GetItems();

            return View();
        }

        
        public ActionResult AddItem(CostItem item)
        {
            item.Date = DateTime.Now;
            item.UserId = 1;
            var repository = new MsSqlRepository();
            repository.Add(item);

            return View("Index");
        }

    }
}
