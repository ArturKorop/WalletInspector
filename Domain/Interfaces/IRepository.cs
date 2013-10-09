using System.Collections.Generic;
using Domain.Code.DatabaseItems;
using Domain.Code.General;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        List<CostItem> GetItems();
    }
}