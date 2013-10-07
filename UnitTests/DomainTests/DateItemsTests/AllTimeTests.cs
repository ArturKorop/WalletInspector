using System;
using System.Collections.Generic;
using Domain.Code.DateItems;
using Domain.Code.Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.DateItemsTests
{
    [TestClass]
    public class AllTimeTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHellper.CreateTagRepository();
        }

        [TestMethod]
        public void SimpleAllTimeTest()
        {
            var item = new CostItemForDataBase
                {
                    Date = new DateTime(2013, 10, 7),
                    Id = 1,
                    Name = "Bread",
                    Price = 4,
                    Tags = new List<int> {1, 4, 6},
                    UserId = 1
                };

            var target = new AllTime(new List<CostItemForDataBase> {item});
            var day = target.GetYear(2013).GetMonth(10).GetDay(7);
            Assert.AreEqual(day.CostItems.Count, 1);
            var costItem = day.CostItems[0];
            Assert.AreEqual(costItem.Name, "Bread");
            Assert.AreEqual(costItem.Price, 4);
            Assert.AreEqual(costItem.Tags[0], "Eat");
            Assert.AreEqual(costItem.Tags[1], "Novus");
            Assert.AreEqual(costItem.Tags[2], "Empty tag");
        }
    }
}