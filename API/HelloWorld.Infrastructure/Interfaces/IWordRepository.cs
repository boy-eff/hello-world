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
        Task AddWordsAsync(ICollection<Word> words);
        Task RemoveWordsByCollectionAsync(int wordCollectionId);
        Word GetWordById(int wordId);
    }
}