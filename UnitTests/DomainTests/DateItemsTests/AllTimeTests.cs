using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Code.Common;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Code.Repository;
using Domain.Code.Time;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.Common;

namespace UnitTests.DomainTests.DateItemsTests
{
    [TestClass]
    public class AllTimeTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHellper.CreateTagRepository();}

        [TestMethod]
        public void SimpleAllTimeTest()
        {
            var item = new CostItem
                {
                    Date = new DateTime(2013, 10, 7),
                    Id = 1,
                    Name = "Bread",
                    Price = 4,
                    TagsIds = new List<int> {1, 4, 6},
                    UserId = 1
                };

            item.SetTagNames(DIServiceLocator.Current.Resolve<ITagRepository>());

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
    }
}