using Domain.Interfaces;

namespace Domain.Code.Repository
{
    public class MsSqlTagRepository : ITagRepository
    {
        public string GetTagName(int id)
        {
            return "Empty tag";
        }

        public int GetTagId(string name)
        {
            return 0;
        }

        public void SaveTag(string tag)
        {
            
        }
    }
}