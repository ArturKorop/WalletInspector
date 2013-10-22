using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.General;
using Domain.Interfaces;

namespace Domain.Code.Repository
{
    public class MsSqlTagRepository : ITagRepository
    {
        private readonly WalletInspectorContext _context;
        private int _userId;

        public MsSqlTagRepository()
        {
            _context = new WalletInspectorContext();
        }

        public void Configure(int userId)
        {
            _userId = userId != -1 ? userId : 0;
        }

        public string GetTagName(int id)
        {
            return _context.Tags.Single(x=>x.Id == id).Name;
        }

        public int GetTagId(string name)
        {
            var temp = _context.Tags.SingleOrDefault(x => x.Name == name && x.UserId == _userId);
            if (temp == null)
            {
                _context.Tags.Add(new Tag(name, _userId));
            }

            _context.SaveChanges();

            return _context.Tags.Single(x => x.Name == name && x.UserId == _userId).Id;
        }

        public void SaveTag(string tag)
        {
            _context.Tags.Add(new Tag(tag, _userId));
            _context.SaveChanges();
        }
    }
}