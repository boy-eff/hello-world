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
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public void AddReview(WordCollectionReview review)
        {
            _context.WordCollectionReviews.Add(review);
        }

        public async Task<WordCollectionReview> GetReview(int id)
        {
            return await _context.WordCollectionReviews.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WordCollectionReview>> GetReviewsAsync()
        {
            return await _context.WordCollectionReviews.ToListAsync();
        }
    }
}