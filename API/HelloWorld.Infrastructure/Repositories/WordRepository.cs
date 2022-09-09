using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Infrastructure.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly DataContext _context;
        public WordRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddWordWithoutSavingAsync(Word word)
        {
            await _context.Words.AddAsync(word);
        }

        public async Task DeleteWordWithoutSavingAsync(int wordId)
        {
            var word = await _context.Words.FirstOrDefaultAsync(w => w.Id == wordId);
            word.IsDeleted = true;
        }

        public Word GetWordById(int wordId)
        {
            return _context.Words.FirstOrDefault(word => word.Id == wordId);
        }

        public async Task<IEnumerable<Word>> GetWordsByCollection(int collectionId)
        {
            return await _context.Words.Where(word => word.WordCollectionId == collectionId).ToListAsync();
        }

        public IEnumerable<Word> GetWordsByIdsWithoutSaving(IEnumerable<int> ids)
        {
            return _context.Words.Where(word => ids.Contains(word.Id));
        }
    }
}