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
        ICollectionThemeRepository CollectionThemeRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}