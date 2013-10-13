using System.Collections.Generic;
using System.Linq;
using Domain.Code.Common;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using Moq;

namespace UnitTests.Common
{
    public static class TestHelper
    {
        private static readonly Dictionary<int, string> Tags;
 
        static TestHelper()
        {
            Tags = new Dictionary<int, string>
                {
                    {1, "Eat"},
                    {2, "Sport"},
                    {3, "Entertainment"},
                    {4, "Novus"}
                };
        }

        public static void CreateTagRepository()
        {
            var mockTagRepository = new Mock<ITagRepository>();

            mockTagRepository.Setup(x => x.GetTagName(It.IsInRange(1, 4, Range.Inclusive))).Returns((int i) => Tags[i]);
            mockTagRepository.Setup(x => x.GetTagName(It.IsInRange(5, 1000, Range.Inclusive))).Returns("Empty tag");

            mockTagRepository.Setup(x => x.GetTagId(It.IsAny<string>())).Returns((string s) => Tags.SingleOrDefault(x => x.Value == s).Key);

            DIServiceLocator.Current.RegisterInstance(mockTagRepository.Object);
        }
    }
}