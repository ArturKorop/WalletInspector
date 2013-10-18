using System;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.StatisticTests
{
    [TestClass]
    public class YearStatisticTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();
        }

        [TestMethod]
        public void GetMonthTotalSumTest()
        {
            var year = new Year(2010);
            year.AddCostItems(new[]
                {
                    new CostItem("Bread", new DateTime(2010,10,10), 12.56),
                    new CostItem("Bread", new DateTime(2010,10,11), 256),
                    new CostItem("Bread", new DateTime(2010,10,12), 0.44),
                    new CostItem("Bread", new DateTime(2010,10,13), 46),
                    new CostItem("Bread", new DateTime(2010,10,14), 5),
                    new CostItem("Bread", new DateTime(2010,1,10), 12.56),
                    new CostItem("Bread", new DateTime(2010,2,11), 256),
                    new CostItem("Bread", new DateTime(2010,3,12), 0.44),
                    new CostItem("Bread", new DateTime(2010,4,13), 46),
                    new CostItem("Bread", new DateTime(2010,7,14), 5)
                });

            var target = year.Statistic;
            Assert.AreEqual(target.GetYearTotalSum(), 640);
        } 
    }
}