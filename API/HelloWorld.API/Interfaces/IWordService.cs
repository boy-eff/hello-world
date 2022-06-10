using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;
using HelloWorld.Domain.Entities;

namespace HelloWorld.API.Interfaces
{
    public interface IWordService
    {
        Task AddWordAsync(WordDto word);
        Word GetWordById(int wordId);
        Task<IEnumerable<WordDto>> GetWordsByCollection(int collectionId);
        Task DeleteWordAsync(int wordId);
    }
}