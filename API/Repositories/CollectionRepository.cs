using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DataContext _context;
        public CollectionRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCollection(WordCollection collection)
        {
            _context.WordCollections.Add(collection);
        }

        public async Task<IEnumerable<WordCollection>> GetCollectionsAsync()
        {
            return await _context.WordCollections.ToListAsync();
        }
    }
}