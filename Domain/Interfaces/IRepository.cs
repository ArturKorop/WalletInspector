using Domain.Code.General;
using Domain.Code.Time;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        Year GetYear(int year);
        Month GetMonth(int year, int month);
        int Add(CostItem item);
        void Update(int id, CostItem item);
        void Remove(int id);
        CostItem GetItemById(int id);
        void SetUserId(int id);
    }
}