using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Data;
using HelloWorld.Infrastructure.Interfaces;
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

        public async Task AddWordAsync(Word word)
        {
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
        }

        public async Task AddWordsAsync(ICollection<Word> words)
        {
            await _context.AddRangeAsync(words);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWordAsync(int wordId)
        {
            var word = await _context.Words.FirstOrDefaultAsync(w => w.Id == wordId);
            word.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public Word GetWordById(int wordId)
        {
            return _context.Words.FirstOrDefault(word => word.Id == wordId);
        }

        public async Task<IEnumerable<Word>> GetWordsByCollection(int collectionId)
        {
            return await _context.Words.Where(word => word.WordCollectionId == collectionId).ToListAsync();
        }

        public async Task RemoveWordsByCollectionAsync(int wordCollectionId)
        {
            _context.Remove(_context.Words.Where(word => word.WordCollectionId == wordCollectionId));
            await _context.SaveChangesAsync();
        }
    }
}