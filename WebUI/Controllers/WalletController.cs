using System;
using System.Web.Mvc;
using Domain.Code.Common;
using Domain.Code.General;
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
            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return View("Month", temp);
        }

        public ActionResult AddItem(CostItem item)
        {
            _repository.Add(item);
            return  RedirectToAction("Month");
        }

        public ActionResult UpdateItem(CostItem item, int id)
        {
            _repository.Update(id, item);
            return RedirectToAction("Month");
        }

        public ActionResult DeleteItem(int id)
        {
            _repository.Remove(id);
            return RedirectToAction("Month");
        }
    }
}
