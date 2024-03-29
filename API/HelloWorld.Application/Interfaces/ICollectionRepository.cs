using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<WordCollection>> GetCollectionsAsync();
        Task AddCollection(WordCollection collection);
        Task<IEnumerable<WordCollection>> GetUserCollectionsAsync(int userId);
        Task<WordCollection> GetWordCollectionAsync(int collectionId);
        Task SaveChangesAsync();
    }
}