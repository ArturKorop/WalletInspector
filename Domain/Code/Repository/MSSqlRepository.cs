using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Interfaces;

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

        public List<CostItem> GetMontItems(int year, int month)
        {
            return _context.CostItems.Where(x => x.Date.Year == year && x.Date.Month == month).ToList();
        }

        public void Change(int id, CostItem item)
        {
            _context.CostItems.Add(item);
            RemoveItemById(id);
        }

        public void Remove(int id)
        {
            RemoveItemById(id);
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

        private CostItem GetItemById(int id)
        {
            return _context.CostItems.Single(x => x.Id == id);
        }

        private void RemoveItemById(int id)
        {
            var itemToRemove = GetItemById(id);
            _context.CostItems.Remove(itemToRemove);
            _context.SaveChanges();
        }
    }
}