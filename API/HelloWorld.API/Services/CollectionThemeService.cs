using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.Shared.DTO;
using HelloWorld.API.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;

namespace HelloWorld.API.Services
{
    public class CollectionThemeService : ICollectionThemeService
    {
        private readonly IMapper _mapper;
        private readonly ICollectionThemeRepository _collectionThemeRepository;

        public CollectionThemeService(ICollectionThemeRepository collectionThemeRepository, IMapper mapper)
        {
            _collectionThemeRepository = collectionThemeRepository;
            _mapper = mapper;
        }

        public async Task<WordCollectionTheme> GetCollectionThemeById(int id)
        {
            return await _collectionThemeRepository.GetThemeByIdAsync(id);
        }

        public async Task<IEnumerable<WordCollectionThemeDto>> GetCollectionThemesAsync()
        {
            var themes =  await _collectionThemeRepository.GetCollectionThemesAsync();
            return _mapper.Map<IEnumerable<WordCollectionTheme>, IEnumerable<WordCollectionThemeDto>>(themes);
        }
    }
}