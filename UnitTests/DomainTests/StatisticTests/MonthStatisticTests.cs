using System;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.StatisticTests
{
    [TestClass]
    public class MonthStatisticTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();
        }

        [TestMethod]
        public void GetMonthTotalSumTest()
        {
            var month = new Month(2010,10);
            month.AddCostItems(new []
                {
                    new CostItem("Bread", new DateTime(2010,10,10), 12.56),
                    new CostItem("Bread", new DateTime(2010,10,11), 256),
                    new CostItem("Bread", new DateTime(2010,10,12), 0.44),
                    new CostItem("Bread", new DateTime(2010,10,13), 46),
                    new CostItem("Bread", new DateTime(2010,10,14), 5)
                });

            var target = month.Statistic;
            Assert.AreEqual(target.GetMonthTotalSum(), 320);
        }
    }
}