using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Code.Common;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Interfaces;
using Microsoft.Practices.Unity;

namespace Domain.Code.Repository
{
    public class MsSqlRepository : IRepository
    {
        private readonly WalletInspectorContext _context;
        private readonly ITagRepository _tagRepository;

        public MsSqlRepository()
        {
            _context = new WalletInspectorContext();
            _tagRepository = DIServiceLocator.Current.Resolve<ITagRepository>();
        }

        public List<CostItem> GetItems()
        {
            var costItems = new List<CostItem>(_context.CostItems.Select(x=>x));
            Parallel.ForEach(costItems, costItem => costItem.SetTagNames());

            return costItems;
        }

        public void Add(CostItem item)
        {
            item.SetTagIds();
            _context.CostItems.Add(item);
            _context.SaveChanges();
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
    }
}