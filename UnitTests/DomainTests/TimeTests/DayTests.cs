using System;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.TimeTests
{
    [TestClass]
    public class DayTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();
        }

        [TestMethod]
        public void AddTest()
        {
            var day = new Day(new DateTime(2000, 10, 10));
            day.Add(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5));

            Assert.AreEqual(day.CostItems.Count, 1);
        }

        [TestMethod]
        public void AddFiveItemsTest()
        {
            var day = new Day(new DateTime(2000, 10, 10));
            for (int i = 0; i < 5; i++)
            {
                day.Add(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5));
            }

            Assert.AreEqual(day.CostItems.Count, 5);
        }

        [TestMethod]
        public void RemoveByItemTest()
        {
            var day = new Day(new DateTime(2000, 10, 10));
            day.Add(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5) {Id = 0});
            day.Add(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5) {Id = 1});
            day.Remove(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5) {Id = 0});

            Assert.AreEqual(day.CostItems.Count, 1);
        }

        [TestMethod]
        public void RemoveByIdTest()
        {
            var day = new Day(new DateTime(2000, 10, 10));
            day.Add(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5) { Id = 0 });
            day.Add(new CostItem("Bread", new DateTime(2010, 10, 10), 4.5) { Id = 1 });
            day.Remove(1);

            Assert.AreEqual(day.CostItems.Count, 1);
        }
    }
}