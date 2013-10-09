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
    }
}