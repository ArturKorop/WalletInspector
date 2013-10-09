﻿using System;
using System.Collections.Generic;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.DateItemsTests
{
    [TestClass]
    public class YearTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHellper.CreateTagRepository();
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth13Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(13);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth0Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(0);
        }
    }
}