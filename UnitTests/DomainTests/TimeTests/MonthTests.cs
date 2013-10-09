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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateDay0Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(1).GetDay(0);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void WrongDateDay32Test()
        {
            var target = new AllTime(new List<CostItem>());
            target.GetYear(2013).GetMonth(1).GetDay(32);
        }
    }
}