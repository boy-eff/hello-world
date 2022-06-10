using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.API.DTO;
using HelloWorld.API.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;

namespace HelloWorld.API.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        public WordService(IWordRepository wordRepository, IMapper mapper)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
        }

        public async Task AddWordAsync(WordDto wordDto)
        {
            var word = _mapper.Map<Word>(wordDto);
            await _wordRepository.AddWordAsync(word);
        }

        public async Task DeleteWordAsync(int wordId)
        {
            await _wordRepository.DeleteWordAsync(wordId);
        }

        public Word GetWordById(int wordId)
        {
            return _wordRepository.GetWordById(wordId);
        }

        public async Task<IEnumerable<WordDto>> GetWordsByCollection(int collectionId)
        {
            var words = _mapper.Map<IEnumerable<Word>,
                IEnumerable<WordDto>>(await _wordRepository.GetWordsByCollection(collectionId));
            return words;
        }
    }
}