using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace HelloWorld.Infrastructure.Repositories
{
    public class CollectionThemeRepository : ICollectionThemeRepository
    {
        private readonly DataContext _context;
        public CollectionThemeRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<WordCollectionTheme>> GetCollectionThemesAsync()
        {
            return await _context.WordCollectionThemes.ToListAsync();
        }

        public async Task<WordCollectionTheme> GetThemeByIdAsync(int id)
        {
            return await _context.WordCollectionThemes.FindAsync(id);
        }
    }
}