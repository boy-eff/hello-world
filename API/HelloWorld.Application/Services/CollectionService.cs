using AutoMapper;
using HelloWorld.Shared.DTO;
using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using HelloWorld.Application.Interfaces;

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

        public async Task UpdateWordsAsync(int collectionId, WordDto[] words)
        {
            foreach (var wordDto in words)
            {
                if (wordDto.IsDeleted && wordDto.Id != null)
                {
                    await _wordService.DeleteWordWithoutSavingAsync(wordDto.Id.GetValueOrDefault());
                }
                else if (wordDto.Id != null)
                {
                    words.Where(word => word.Id != null && !word.IsDeleted);
                }
                else if (!wordDto.IsDeleted)
                {
                    await _wordService.AddWordAsync(wordDto);
                }
            }

            await _collectionRepository.SaveChangesAsync();
        }
    }
}