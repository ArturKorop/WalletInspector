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
            if (Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(item.Date.Year, item.Date.Month).GetDay(item.Date.Day);
                return PartialView("Day", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("Month", temp);
        }

        public ActionResult UpdateItem(CostItem item, int id)
        {
            _repository.Update(id, item);
            if (Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(item.Date.Year, item.Date.Month).GetDay(item.Date.Day);
                return PartialView("Day", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("Month", temp);
        }

        public ActionResult DeleteItem(int id)
        {
            _repository.Remove(id);
            if(Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(2013, 10).GetDay(10);
                return PartialView("Day", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("Month", temp);
        }
    }
}
