using System;
using System.Web.Mvc;
using System.Web.UI;
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
            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return View("Month", temp);
        }

        [HttpPost]
        public ActionResult AddItem(CostItem item)
        {
            ModelState.Clear();
            if (item.IsValid())
                _repository.Add(item);

            if (Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(item.Date.Year, item.Date.Month).GetDay(item.Date.Day);
                return PartialView("DayInDiv", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("Month", temp);
        }

        [HttpPost]
        public ActionResult UpdateItem(CostItem item, int id)
        {
            ModelState.Clear();
            _repository.Update(id, item);
            if (Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(item.Date.Year, item.Date.Month).GetDay(item.Date.Day);
                var temp2 = PartialView("DayInDiv", result);
                return temp2;
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("Month", temp);
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            var date = _repository.GetItemById(id).Date;
            _repository.Remove(id);
            if(Request.IsAjaxRequest())
            {
                //TODO: refactore this for _repository.GetDay()
                var result = _repository.GetMonth(date.Year, date.Month).GetDay(date.Day);
                return PartialView("DayInDiv", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("Month", temp);
        }
    }
}
