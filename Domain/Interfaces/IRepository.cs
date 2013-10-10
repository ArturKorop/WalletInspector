using System.Collections.Generic;
using Domain.Code.General;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        List<CostItem> GetItems();
        List<CostItem> GetYearItems(int year);
        List<CostItem> GetMontItems(int year, int month);
        int Add(CostItem item);
        void Change(int id, CostItem item);
        void Remove(int id);
    }
}