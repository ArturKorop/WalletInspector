using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<CostItem> GetItems()
        {
            var costItems = new List<CostItem>(_context.CostItems.Select(x=>x));
            Parallel.ForEach(costItems, costItem => costItem.SetTagNames());

            return costItems;
        }

        public List<CostItem> GetYearItems(int year)
        {
            return _context.CostItems.Where(x => x.Date.Year == year).ToList();
        }

        public List<CostItem> GetMonthItems(int year, int month)
        {
            return _context.CostItems.Where(x => x.Date.Year == year && x.Date.Month == month).ToList();
        }

        public Year GetYear(int year)
        {
            var tempYear = new Year(year);
            var items = GetYearItems(year);
            foreach (var costItem in items)
            {
                tempYear.AddCostItem(costItem);
            }

            return tempYear;
        }

        public Month GetMonth(int year, int month)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, CostItem item)
        {
            var tempItem = _context.CostItems.Single(x => x.Id == id);
            tempItem.Update(item);
            _context.SaveChanges();

            /*_context.CostItems.Where(x => x.Id == id).Update(()=>{});
            _context.CostItems.Add(item);
            RemoveItemById(id);*/
        }

        public void Remove(int id)
        {
            _context.CostItems.Delete(x => x.Id == id);
            _context.SaveChanges();
        }

        public int Add(CostItem item)
        {
            item.SetTagIds();
            _context.CostItems.Add(item);
            _context.SaveChanges();
            var list = _context.CostItems.Select(x => x).ToList();
            int id = list.Single(x => x.Name == item.Name && x.Date == item.Date).Id;

            return id;
        }

        public List<Tag> GetTags()
        {
            return new List<Tag>(_context.Tags.Select(x=>x));
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        private void RemoveItemById(int id)
        {
            _context.CostItems.Delete(x=>x.Id == id);
            _context.SaveChanges();
        }
    }
}