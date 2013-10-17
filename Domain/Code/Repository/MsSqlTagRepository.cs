using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Interfaces;

namespace Domain.Code.Repository
{
    public class MsSqlTagRepository : ITagRepository
    {
        private readonly WalletInspectorContext _context;

        public MsSqlTagRepository()
        {
            _context = new WalletInspectorContext();
        }

        public string GetTagName(int id)
        {
            return _context.Tags.Single(x=>x.Id == id).Name;
        }

        public int GetTagId(string name)
        {
            var temp = _context.Tags.SingleOrDefault(x => x.Name == name);
            if (temp == null)
            {
                _context.Tags.Add(new Tag(name));
            }

            _context.SaveChanges();

            return _context.Tags.Single(x => x.Name == name).Id;
        }

        public void SaveTag(string tag)
        {
            _context.Tags.Add(new Tag(tag));
            _context.SaveChanges();
        }
    }
}