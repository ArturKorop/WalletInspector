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

        [HttpGet]
        public ActionResult AddItem(CostItem item)
        {
            var tempItem = new CostItem
                {
                    Name =  item.Name,
                    Price = item.Price,
                    Date = DateTime.Now,
                    TagsIds = item.TagsIds,
                    UserId = 1
                };

            var repository = new MsSqlRepository();
            repository.Add(tempItem);

            return View("Index");
        }

    }
}
