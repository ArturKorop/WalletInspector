using System;
using System.Collections.Generic;
using Domain.Code.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests.DomainTests.GeneralTests
{
    [TestClass]
    public class CostIItemsTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            TestHelper.CreateTagRepository();
        }

        [TestMethod]
        public void CostItemCreateTett()
        {
            var target = new CostItem("Bread", new DateTime(2010, 10, 10), 12);

            Assert.AreEqual(target.Name, "Bread");
            Assert.AreEqual(target.Date, new DateTime(2010, 10, 10));
            Assert.AreEqual(target.Price, 12);
            Assert.AreEqual(target.Id, 0);
        }

        [TestMethod]
        public void SetTagNamesTest()
        {
            var target = new CostItem("Bread", new DateTime(2010, 10, 10), 12);
            target.TagIds.Add(1);
            target.SetTagNames();

            Assert.AreEqual(target.TagNames.Count, 1);
            Assert.AreEqual(target.TagNames[0], "Eat");
        }

        [TestMethod]
        public void SetTagNamesManyTest()
        {
            var target = new CostItem("Bread", new DateTime(2010, 10, 10), 12);
            target.TagIds.Add(1);
            target.TagIds.Add(2);
            target.SetTagNames();

            Assert.AreEqual(target.TagNames.Count, 2);
            Assert.AreEqual(target.TagNames[0], "Eat");
            Assert.AreEqual(target.TagNames[1], "Sport");

            target.TagIds = new List<int>{1};
            target.SetTagNames();

            Assert.AreEqual(target.TagNames.Count, 1);
            Assert.AreEqual(target.TagNames[0], "Eat");
        }

        [TestMethod]
        public void SetTagIdsTest()
        {
            var target = new CostItem("Bread", new DateTime(2010, 10, 10), 12);
            target.TagNames.Add("Eat");
            target.SetTagIds();

            Assert.AreEqual(target.TagIds.Count, 1);
            Assert.AreEqual(target.TagIds[0], 1);
        }

        [TestMethod]
        public void SetTagIdsManyTest()
        {
            var target = new CostItem("Bread", new DateTime(2010, 10, 10), 12);
            target.TagNames.Add("Eat");
            target.TagNames.Add("Sport");
            target.SetTagIds();

            Assert.AreEqual(target.TagIds.Count, 2);
            Assert.AreEqual(target.TagIds[0], 1);
            Assert.AreEqual(target.TagIds[1], 2);

            target.TagNames = new List<string>
                {
                    "Eat"
                };
            target.SetTagIds();

            Assert.AreEqual(target.TagIds.Count, 1);
            Assert.AreEqual(target.TagIds[0], 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var item = new CostItem("Bread", new DateTime(2010, 10, 10), 12);
            item.TagIds.Add(1);
            item.SetTagNames();

            var target = new CostItem("Boots", new DateTime(2011, 11, 11), 23);
            item.TagIds.Add(2);
            item.SetTagNames();

            target.Update(item);

            Assert.AreEqual(target.Name, "Bread");
            Assert.AreEqual(target.Price, 12);
            Assert.AreEqual(target.TagIds[0], 1);
            Assert.AreEqual(target.TagNames[0], "Eat");

            Assert.AreEqual(target.Date, new DateTime(2011, 11, 11));
        }
    }
}