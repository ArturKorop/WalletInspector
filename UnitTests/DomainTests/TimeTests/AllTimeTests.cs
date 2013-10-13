using System;
using System.Collections.Generic;
using Domain.Code.Common;
using Domain.Code.General;
using Domain.Code.Time;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.TimeTests
{
    [TestClass]
    public class AllTimeTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();}

        [TestMethod]
        public void SimpleAllTimeTest()
        {
            var item = new CostItem("Bread",new DateTime(2013, 10, 7), 4)
                {
                    Id = 1,
                    TagIds = new List<int> {1, 4, 6},
                    UserId = 1
                };

            item.SetTagNames();

            var target = new AllTime(new []{item});
            var day = target.GetYear(2013).GetMonth(10).GetDay(7);
            Assert.AreEqual(day.CostItems.Count, 1);
            var costItem = day.CostItems[0];
            Assert.AreEqual(costItem.Name, "Bread");
            Assert.AreEqual(costItem.Price, 4);
            Assert.AreEqual(costItem.TagNames[0], "Eat");
            Assert.AreEqual(costItem.TagNames[1], "Novus");
            Assert.AreEqual(costItem.TagNames[2], "Empty tag");
        }

        [TestMethod]
        public void GetDayTest()
        {
            var allTime = new AllTime();
            var target = allTime.GetDay(2000, 10, 10);

            Assert.IsNotNull(target);
            Assert.AreEqual(target.Date, new DateTime(2000,10,10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetDayWrongDayTest()
        {
            var allTime = new AllTime();
            allTime.GetDay(2000, 10, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetDayWrongMonthTest()
        {
            var allTime = new AllTime();
            allTime.GetDay(2000, 14, 10);

        }

        [TestMethod]
        public void GetYearTest()
        {
            var allTime = new AllTime();
            var target = allTime.GetYear(2000);

            Assert.IsNotNull(target);
            Assert.AreEqual(target.Name, 2000);
        }
    }
}