using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.API.DTO;
using HelloWorld.API.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.API.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly ICollectionRepository _collectionRepository;
        private readonly ICollectionThemeRepository _collectionThemeRepository;
        private readonly IWordService _wordService;
        public CollectionService(ICollectionRepository collectionRepository, IMapper mapper,
         UserManager<AppUser> userManager, IUserService userService,
        ICollectionThemeRepository collectionThemeRepository, IWordService wordService)
        {
            _wordService = wordService;
            _collectionThemeRepository = collectionThemeRepository;
            _collectionRepository = collectionRepository;
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            
        }

        public async Task AddCollection(CollectionCreateDto collectionDto, int userId)
        {
            var collection = _mapper.Map<WordCollection>(collectionDto);
            collection.Theme = await _collectionThemeRepository.GetThemeByIdAsync(collectionDto.ThemeId);
            collection.OwnerId = userId;    
            await _collectionRepository.AddCollection(collection);
        }

        public async Task<IEnumerable<CollectionDto>> GetCollectionsAsync()
        {
            var collections = await _collectionRepository.GetCollectionsAsync();
            var collectionsDto = _mapper.Map<IEnumerable<WordCollection>, IEnumerable<CollectionDto>>(collections);
            return collectionsDto;
        }

        public async Task<IEnumerable<CollectionDto>> GetUserCollectionsAsync(int userId)
        {
            var collections = await _collectionRepository.GetUserCollectionsAsync(userId);
            var collectionsDto = _mapper.Map<IEnumerable<WordCollection>, IEnumerable<CollectionDto>>(collections);
            return collectionsDto;
        }

        public async Task<CollectionDto> GetWordCollectionAsync(int collectionId)
        {
            var collection = await _collectionRepository.GetWordCollectionAsync(collectionId);
            var dto = _mapper.Map<CollectionDto>(collection);
            return dto;
        }

        public async Task UpdateCollectionAsync(CollectionUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateWordsAsync(int collectionId, WordDto[] words)
        {
            foreach (var wordDto in words)
            {
                var word = _wordService.GetWordById(wordDto.Id);
                if (word != null)
                {
                    _mapper.Map(wordDto, word);
                    await _collectionRepository.SaveChangesAsync();
                }
                else
                {
                    await _wordService.AddWordAsync(wordDto);
                }
            }
        }
    }
}