using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface IWordRepository
    {
        Task AddWordWithoutSavingAsync(Word word);
        Word GetWordById(int wordId);
        IEnumerable<Word> GetWordsByIdsWithoutSaving(IEnumerable<int> ids);
        Task<IEnumerable<Word>> GetWordsByCollection(int collectionId);
        Task DeleteWordWithoutSavingAsync(int wordId);
    }
}