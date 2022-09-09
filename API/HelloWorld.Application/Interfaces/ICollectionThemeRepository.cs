using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface ICollectionThemeRepository
    {
        Task<IEnumerable<WordCollectionTheme>> GetCollectionThemesAsync();
        Task<WordCollectionTheme> GetThemeByIdAsync(int id);
    }
}