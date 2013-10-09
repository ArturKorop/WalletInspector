namespace Domain.Interfaces
{
    public interface ITagRepository
    {
        string GetTagName(int id);
        int GetTagId(string name);
        void SaveTag(string tag);
    }
}