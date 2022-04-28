using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Infrastructure.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<WordCollectionReview>> GetReviewsAsync();
        void AddReview(WordCollectionReview review);
        Task<WordCollectionReview> GetReview(int id);
    }
}