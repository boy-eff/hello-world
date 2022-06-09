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
        Task AddWordsAsync(ICollection<WordDto> wordsDto);
        Task RemoveWordsByCollectionAsync(int collectionId);
        Word GetWordById(int wordId);
    }
}