using System.Collections.Generic;
using Domain.Code.DatabaseItems;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        List<CostItemForDataBase> GetItems();
    }
}