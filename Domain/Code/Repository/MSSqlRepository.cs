using System.Collections.Generic;
using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Code.Time;
using Domain.Interfaces;
using EntityFramework.Extensions;

namespace Domain.Code.Repository
{
    public class MsSqlRepository : IRepository
    {
        private readonly WalletInspectorContext _context;

        public MsSqlRepository()
        {
            _context = new WalletInspectorContext();
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
            var tempItem = _context.CostItems.Single(x => x.Id == id);
            tempItem.Update(item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.CostItems.Delete(x => x.Id == id);
            _context.SaveChanges();
        }

        public CostItem GetItemById(int id)
        {
            return _context.CostItems.Single(x => x.Id == id);
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
            return _context.CostItems.Where(x => x.Date.Year == year).ToList();
        }

        private IEnumerable<CostItem> GetMonthItems(int year, int month)
        {
            return _context.CostItems.Where(x => x.Date.Year == year && x.Date.Month == month).ToList();
        }
    }
}