using System;
using System.Collections.Generic;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.TimeTests
{
    [TestClass]
    public class YearTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();
        }

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth13Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(13);
        }

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth0Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(0);
        }

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongYear1800Test()
        {
            var target = new Year(1800);

            Assert.IsNull(target);
        }

        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongYear2200Test()
        {
            var target = new Year(2200);

            Assert.IsNull(target);
        }

        [TestMethod]
        public void CreateYearTest()
        {
            var target = new Year(2010);

            Assert.AreEqual(target.Months.Length, 12);
            Assert.AreEqual(target.Name, 2010);
        }

        [TestMethod]
        public void AddItemTest()
        {
            var target = new Year(2010);
            target.AddCostItem(new CostItem("Bread", new DateTime(2010, 10, 10), 34));
            var item = target.GetMonth(10).GetDay(10).CostItems[0];

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Bread");
            Assert.AreEqual(item.Price, 34);
            Assert.AreEqual(item.Date, new DateTime(2010, 10, 10));
        }

        [TestMethod]
        public void AddItemsTest()
        {
            var target = new Year(2010);
            target.AddCostItems(new[]
                {
                    new CostItem("Bread", new DateTime(2010, 10, 10), 34),
                    new CostItem("Bread2", new DateTime(2010, 11, 11), 5)
                });
            var item = target.GetMonth(10).GetDay(10).CostItems[0];

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Bread");
            Assert.AreEqual(item.Price, 34);
            Assert.AreEqual(item.Date, new DateTime(2010, 10, 10));

            item = target.GetMonth(11).GetDay(11).CostItems[0];

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Bread2");
            Assert.AreEqual(item.Price, 5);
            Assert.AreEqual(item.Date, new DateTime(2010, 11, 11));
        }

        [ExpectedException(typeof (ArgumentException))]
        [TestMethod]
        public void AddWrongItemTest()
        {
            var target = new Year(2010);
            target.AddCostItem(new CostItem("Bread", new DateTime(2011, 10, 10), 34));
        }

        [ExpectedException(typeof (ArgumentException))]
        [TestMethod]
        public void AddWrongItemsTest()
        {
            var target = new Year(2010);
            target.AddCostItems(new[] {new CostItem("Bread", new DateTime(2011, 10, 10), 34)});
        }
    }
}