using System;
using System.Collections.Generic;
using Domain.Code.DateItems;
using Domain.Code.Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.DateItemsTests
{
    [TestClass]
    public class MonthTests
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
            var target = new AllTime(new List<CostItemForDataBase>());
            target.GetYear(2013).GetMonth(1).GetDay(0);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth0Test()
        {
            var target = new AllTime(new List<CostItemForDataBase>());
            target.GetYear(2013).GetMonth(1).GetDay(32);
        }
    }
}