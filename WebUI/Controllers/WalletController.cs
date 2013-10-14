using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Code.Common;
using Domain.Code.General;
using Domain.Code.Time;
using Domain.Interfaces;
using Microsoft.Practices.Unity;


namespace WebUI.Controllers
{
    public class WalletController : Controller
    {
        private readonly IRepository _repository;

        public WalletController()
        {
            _repository = DIServiceLocator.Current.Resolve<IRepository>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Month()
        {
            for (int i = 0; i < 10; i++)
            {
                _repository.Add(new CostItem("Bread" + i, DateTime.Now, 12 + i));
            }

            var temp = _repository.GetMonth(2013, 10);
            return View("Month", temp);
        }
    }
}
