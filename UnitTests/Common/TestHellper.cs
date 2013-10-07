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
            mockTagRepository.Setup(x => x.GetTag(1)).Returns("Eat");
            mockTagRepository.Setup(x => x.GetTag(2)).Returns("Sport");
            mockTagRepository.Setup(x => x.GetTag(3)).Returns("Entertainment");
            mockTagRepository.Setup(x => x.GetTag(4)).Returns("Novus");
            mockTagRepository.Setup(x => x.GetTag(It.IsInRange(5, 1000, Range.Exclusive))).Returns("Empty tag");

            DIServiceLocator.Current.RegisterInstance(mockTagRepository.Object);
        }
    }
}