using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Infrastructure.Data;
using HelloWorld.Infrastructure.Interfaces;

namespace HelloWorld.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;

        }
        public IUserRepository UserRepository => new UserRepository(_context);

        public ICollectionRepository CollectionRepository => new CollectionRepository(_context);
        public IReviewRepository ReviewRepository => new ReviewRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}