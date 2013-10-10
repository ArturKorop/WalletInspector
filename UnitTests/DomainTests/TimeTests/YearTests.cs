using System;
using System.Collections.Generic;
using Domain.Code.General;
using Domain.Code.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DomainTests.TimeTests
{
    [TestClass]
    public class YearTests
    {
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth13Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(13);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateMonth0Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(0);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongYear1800Test()
        {
            var target = new Year(1800);

            Assert.IsNull(target);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
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
    }
}