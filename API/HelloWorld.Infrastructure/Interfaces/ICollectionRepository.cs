using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Infrastructure.Interfaces
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<WordCollection>> GetCollectionsAsync();
        void AddCollection(WordCollection collection);
    }
}