using Microsoft.Practices.Unity;

namespace Domain.Code.Common
{
    public static class DIServiceLocator
    {
        private static IUnityContainer _container = new UnityContainer();

        public static void SetContainer(IUnityContainer container)
        {
            _container = container;
        }

        public static IUnityContainer Current
        {
            get { return _container; }
        }
    }
}