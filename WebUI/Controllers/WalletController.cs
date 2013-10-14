﻿using System;
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
            var temp = _repository.GetMonth(2010, 10);
            return View("Month", temp);
        }

        public void AddItem(CostItem item)
        {
            var temp = item;
            var fd = temp;
        }

        public void UpdateItem(CostItem item)
        {
            var temp = item;
            var fd = temp;
        }

        public void DeleteItem(int id)
        {
            var temp = id;
            var fd = temp;
        }
    }
}
