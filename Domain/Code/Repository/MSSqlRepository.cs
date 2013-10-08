using System.Collections.Generic;
using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.DatabaseItems.Contexts;
using Domain.Interfaces;

namespace Domain.Code.Repository
{
    public class MSSqlRepository : IRepository
    {
        private readonly WalletInspectorContext _context;

        public MSSqlRepository()
        {
            _context = new WalletInspectorContext();
        }

        public List<CostItemForDataBase> GetItems()
        {
            return new List<CostItemForDataBase>(_context.CostItems.Select(x=>x));
        }

        public void Add(CostItemForDataBase item)
        {
            _context.CostItems.Add(item);
        }

        public List<Tag> GetTags()
        {
            return new List<Tag>(_context.Tags.Select(x=>x));
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
        }
    }
}