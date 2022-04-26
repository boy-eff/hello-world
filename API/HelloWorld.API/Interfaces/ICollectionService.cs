using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;

namespace HelloWorld.API.Interfaces
{
    public interface ICollectionService
    {
        void AddCollection(CreateCollectionDto collectionDto, int userId);
        Task<IEnumerable<CollectionDto>> GetCollectionsAsync();
    }
}