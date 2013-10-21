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
             var userId = WebSecurity.IsAuthenticated ? WebSecurity.CurrentUserId : 0;
             DIServiceLocator.Current.RegisterInstance<ITagRepository>(new MsSqlTagRepository(userId));
             DIServiceLocator.Current.RegisterInstance<IRepository>(new MsSqlCostItemRepository(userId));
         }
    }
}