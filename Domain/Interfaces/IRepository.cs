using System.Collections.Generic;
using Domain.Code.General;
using Domain.Code.Time;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        List<CostItem> GetItems();
        List<CostItem> GetYearItems(int year);
        List<CostItem> GetMonthItems(int year, int month);
        Year GetYear(int year);
        Month GetMonth(int year, int month);
        int Add(CostItem item);
        void Update(int id, CostItem item);
        void Remove(int id);
    }
}