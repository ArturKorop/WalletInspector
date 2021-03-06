﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Code.Common;
using Domain.Code.General;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using WebMatrix.WebData;
using WebUI.Filters;

namespace WebUI.Controllers
{
    public class WalletController : Controller
    {
        private readonly IRepository _repository;
        private readonly int _userId;

        public WalletController()
        {
            _repository = DIServiceLocator.Current.Resolve<IRepository>();
            _userId = WebSecurity.CurrentUserId;
            _repository.SetUserId(_userId);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrentMonth()
        {
            var date = DateTime.Now;

            return GetMonth(date);
        }

        public ActionResult PrevMonth(DateTime currentMonth)
        {
            var date = currentMonth.AddMonths(-1);

            return GetMonth(date);
        }

        public ActionResult NextMonth(DateTime currentMonth)
        {
            var date = currentMonth.AddMonths(1);

            return GetMonth(date);
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
                return PartialView("DayInDiv", result);
            }

            var temp = _repository.GetMonth(DateTime.Now.Year, DateTime.Now.Month);
            return RedirectToAction("CurrentMonth", temp);
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
            return RedirectToAction("CurrentMonth", temp);
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
            return RedirectToAction("CurrentMonth", temp);
        }

        private ActionResult GetMonth(DateTime date)
        {
            return View("Month", _repository.GetMonth(date.Year, date.Month));
        }
    }
}
