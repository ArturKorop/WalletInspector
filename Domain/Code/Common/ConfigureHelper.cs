using Domain.Code.Repository;
using Domain.Interfaces;
using Microsoft.Practices.Unity;
using WebMatrix.WebData;

namespace Domain.Code.Common
{
    public static class ConfigureHelper
    {
         public static void Configure()
         {
             DIServiceLocator.Current.RegisterInstance<ITagRepository>(new MsSqlTagRepository());
             DIServiceLocator.Current.RegisterInstance<IRepository>(new MsSqlCostItemRepository());
         }
    }
}