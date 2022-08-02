using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface IWordService
    {
        Task AddWordAsync(WordDto word);
        Word GetWordById(int wordId);
        IEnumerable<Word> GetWordsByIdsWithoutSaving(IEnumerable<int> ids);
        Task<IEnumerable<WordDto>> GetWordsByCollection(int collectionId);
        Task DeleteWordWithoutSavingAsync(int wordId);
    }
}