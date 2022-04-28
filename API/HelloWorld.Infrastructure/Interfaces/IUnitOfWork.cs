using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICollectionRepository CollectionRepository { get; }
        IReviewRepository ReviewRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}