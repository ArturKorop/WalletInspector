using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Code.DatabaseItems;
using Domain.Code.DatabaseItems.Contexts;
using Domain.Code.DateItems;
using Domain.Code.Repository;
using Domain.Interfaces;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repository = new MSSqlRepository();
            var temp = repository.GetItems();
            return View();
        }

        public void AddItem(string name, int price)
        {
            var item = new CostItemForDataBase
                {
                    Name =  name,
                    Price = price,
                    Date = DateTime.Now,
                    Tags = new List<int> { 1 },
                    UserId = 1
                };

            var repository = new MSSqlRepository();
            repository.Add(item);
        }

    }
}
