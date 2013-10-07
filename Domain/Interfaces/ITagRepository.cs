namespace Domain.Interfaces
{
    public interface ITagRepository
    {
        string GetTag(int id);
        void SaveTag(string tag);
    }
}