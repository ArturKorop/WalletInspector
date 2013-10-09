using Domain.Code.Common;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using Moq;

namespace UnitTests.Common
{
    public static class TestHellper
    {
        public static void CreateTagRepository()
        {
            var mockTagRepository = new Mock<ITagRepository>();
            mockTagRepository.Setup(x => x.GetTagName(1)).Returns("Eat");
            mockTagRepository.Setup(x => x.GetTagName(2)).Returns("Sport");
            mockTagRepository.Setup(x => x.GetTagName(3)).Returns("Entertainment");
            mockTagRepository.Setup(x => x.GetTagName(4)).Returns("Novus");
            mockTagRepository.Setup(x => x.GetTagName(It.IsInRange(5, 1000, Range.Exclusive))).Returns("Empty tag");

            DIServiceLocator.Current.RegisterInstance(mockTagRepository.Object);
        }
    }
}