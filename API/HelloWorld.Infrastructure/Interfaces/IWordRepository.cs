using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Infrastructure.Interfaces
{
    public interface IWordRepository
    {
        Task AddWordAsync(Word word);
        Word GetWordById(int wordId);
        Task<IEnumerable<Word>> GetWordsByCollection(int collectionId);
        Task DeleteWordAsync(int wordId);
    }
}