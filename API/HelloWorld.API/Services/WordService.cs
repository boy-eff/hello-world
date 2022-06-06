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

        public async Task AddWordsAsync(ICollection<WordDto> wordsDto)
        {
            var words = _mapper.Map<ICollection<WordDto>, ICollection<Word>>(wordsDto);
            await _wordRepository.AddWordsAsync(words);
        }
    }
}