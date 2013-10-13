using System;
using System.Collections.Generic;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.TimeTests
{
    [TestClass]
    public class MonthTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateDay0Test()
        {
            var target = new Month(2010, 10);
            target.GetDay(0);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateDay32Test()
        {
            var target = new Month(2010, 10);
            target.GetDay(33);
        }

        [TestMethod]
        public void CreateMonthTest()
        {
            var target = new Month(2010, 10);
            
            Assert.AreEqual(target.Days.Length, 31);
            Assert.AreEqual(target.MonthNumber, 10);
            Assert.AreEqual(target.ThisYear, 2010);
        }

        [TestMethod]
        public void AddItemTest()
        {
            var target = new Month(2010, 10);
            target.AddCostItem(new CostItem("Bread", new DateTime(2010, 10, 10), 34));
            var item = target.GetDay(10).CostItems[0];

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Bread");
            Assert.AreEqual(item.Price,  34);
            Assert.AreEqual(item.Date, new DateTime(2010, 10, 10));

        }

        [TestMethod]
        public void AddItemsTest()
        {
            var target = new Month(2010, 10);
            target.AddCostItems(new[] { new CostItem("Bread", new DateTime(2010, 10, 10), 34), new CostItem("Bread2", new DateTime(2010, 10, 11), 11) });
            var item = target.GetDay(10).CostItems[0];

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Bread");
            Assert.AreEqual(item.Price, 34);
            Assert.AreEqual(item.Date, new DateTime(2010, 10, 10));

            item = target.GetDay(11).CostItems[0];

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Name, "Bread2");
            Assert.AreEqual(item.Price, 11);
            Assert.AreEqual(item.Date, new DateTime(2010, 10, 11));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddWrongItemTest()
        {
            var target = new Month(2010, 10);
            target.AddCostItem(new CostItem("Bread", new DateTime(2010, 11, 10), 34));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddWrongItemsTest()
        {
            var target = new Month(2010, 10);
            target.AddCostItems(new[] { new CostItem("Bread", new DateTime(2010, 11, 10), 34), new CostItem("Bread2", new DateTime(2010, 10, 11), 11) });
        }
    }
}