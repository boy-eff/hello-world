using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
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