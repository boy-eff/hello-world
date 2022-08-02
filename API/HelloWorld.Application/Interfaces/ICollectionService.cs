using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;

namespace HelloWorld.Application.Interfaces
{
    public interface ICollectionService
    {
        Task AddCollection(CollectionCreateDto collectionDto, int userId);
        Task<IEnumerable<CollectionDto>> GetCollectionsAsync();
        Task<IEnumerable<CollectionDto>> GetUserCollectionsAsync(int userId);
        Task<CollectionDto> GetWordCollectionAsync(int collectionId);
        Task UpdateWordsAsync(int collectionId, WordDto[] words);
    }
}