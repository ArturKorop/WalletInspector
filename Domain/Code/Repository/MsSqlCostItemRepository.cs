using System.Collections.Generic;
using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Code.Time;
using Domain.Interfaces;
using EntityFramework.Extensions;

namespace Domain.Code.Repository
{
    public class MsSqlCostItemRepository : IRepository
    {
        private readonly WalletInspectorContext _context;
        private int _userId;

        public MsSqlCostItemRepository(int userId)
        {
            _context = new WalletInspectorContext();
            _userId = userId != -1 ? userId : 0; ;
        }

        public Year GetYear(int year)
        {
            var tempYear = new Year(year);
            var items = GetYearItems(year);
            tempYear.AddCostItems(items);

            return tempYear;
        }

        public Month GetMonth(int year, int month)
        {
            var tempMonth = new Month(year, month);
            var items = GetMonthItems(year, month);
            tempMonth.AddCostItems(items);

            return tempMonth;
        }

        public void Update(int id, CostItem item)
        {
            var tempItem = _context.CostItems.Single(x => x.Id == id && x.UserId == _userId);
            tempItem.Update(item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.CostItems.Delete(x => x.Id == id && x.UserId == _userId);
            _context.SaveChanges();
        }

        public CostItem GetItemById(int id)
        {
            return _context.CostItems.Single(x => x.Id == id && x.UserId == _userId);
        }

        public int Add(CostItem item)
        {
            item.SetTagIds();
            _context.CostItems.Add(item);
            _context.SaveChanges();

            return item.Id;
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        private IEnumerable<CostItem> GetYearItems(int year)
        {
            return _context.CostItems.Where(x => x.Date.Year == year && x.UserId == _userId).ToList();
        }

        private IEnumerable<CostItem> GetMonthItems(int year, int month)
        {
            return _context.CostItems.Where(x => x.Date.Year == year && x.Date.Month == month && x.UserId == _userId).ToList();
        }
    }
}