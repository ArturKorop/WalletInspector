using System;
using System.Globalization;
using System.Web.Mvc;
using Domain.Code.Common;
using Domain.Code.General;
using Domain.Code.Time;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using WebMatrix.WebData;

namespace WebUI.Controllers
{
    public class WalletController : Controller
    {
        private readonly IRepository _repository;
        private readonly int _userId;

        public WalletController()
        {
            ConfigureHelper.Configure();
            _repository = DIServiceLocator.Current.Resolve<IRepository>();
            _userId = WebSecurity.CurrentUserId;
        }

        public ViewResult CurrentMonth()
        {
            var date = DateTime.Now;

            return GetMonth(date);
        }

        public ViewResult PrevMonth(DateTime currentMonth)
        {
            var date = currentMonth.AddMonths(-1);

            return GetMonth(date);
        }

        public ViewResult NextMonth(DateTime currentMonth)
        {
            var date = currentMonth.AddMonths(1);

            return GetMonth(date);
        }

        public ViewResult PrevYear(int currentYear)
        {
            return Year(currentYear - 1);
        }

        public ViewResult NextYear(int currentYear)
        {
            return Year(currentYear + 1);
        }

        [HttpPost]
        public ActionResult AddItem(CostItem item)
        {
            ModelState.Clear();
            if (item.IsValid())
            {
                item.UserId = _userId;
                _repository.Add(item);
            }

            if (Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(item.Date.Year, item.Date.Month).GetDay(item.Date.Day);
                return PartialView("Day", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return View("Month", temp);
        }

        [HttpPost]
        public ActionResult UpdateItem(CostItem item, int id)
        {
            ModelState.Clear();
            _repository.Update(id, item);
            if (Request.IsAjaxRequest())
            {
                var result = _repository.GetMonth(item.Date.Year, item.Date.Month).GetDay(item.Date.Day);
                return PartialView("Day", result);
            }

            var temp = _repository.GetMonth(item.Date.Year, item.Date.Month);
            return View("Month", temp);
        }

        public ActionResult DeleteItem(int id)
        {
            var date = _repository.GetItemById(id).Date;
            _repository.Remove(id);
            if (Request.IsAjaxRequest())
            {
                //TODO: refactore this for _repository.GetDay()
                var result = _repository.GetMonth(date.Year, date.Month).GetDay(date.Day);
                return PartialView("Day", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return View("Month", temp);
        }

        public ViewResult CurrentYear()
        {
            ViewBag.Title = DateTime.Now.Year;

            return View("Year", _repository.GetYear(DateTime.Now.Year));
        }

        public ViewResult Year(int year)
        {
            ViewBag.Title = year;

            return View("Year", _repository.GetYear(year));
        }

        public ViewResult Month(int year, int month)
        {
            ViewBag.Title = CreateMonthTitleText(new DateTime(year, month, 1));

            return View("Month", _repository.GetMonth(year, month));
        }

        public ViewResult MonthTotalStatistic(DateTime currentMonth)
        {
            var month = _repository.GetMonth(currentMonth.Year, currentMonth.Month);

            return View("MonthTotalStatistic", month);
        }

        private ViewResult GetMonth(DateTime date)
        {
            ViewBag.Title = CreateMonthTitleText(date);

            return View("Month", _repository.GetMonth(date.Year, date.Month));
        }

        private string CreateMonthTitleText(DateTime date)
        {
            return String.Format("{0}: {1}", date.Year,
                                 CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month));
        }
    }
}
