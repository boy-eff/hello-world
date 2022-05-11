using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Infrastructure.Data;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Infrastructure.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DataContext _context;
        public CollectionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddCollection(WordCollection collection)
        {
            _context.WordCollections.Add(collection);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WordCollection>> GetCollectionsAsync()
        {
            return await _context.WordCollections
            .Include(wc => wc.Words)
            .ToListAsync();
        }
    }
}