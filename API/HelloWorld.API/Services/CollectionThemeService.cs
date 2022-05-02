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
    public class CollectionThemeService : ICollectionThemeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CollectionThemeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WordCollectionThemeDto>> GetCollectionThemesAsync()
        {
            var themes =  await _unitOfWork.CollectionThemeRepository.GetCollectionThemesAsync();
            return _mapper.Map<IEnumerable<WordCollectionTheme>, IEnumerable<WordCollectionThemeDto>>(themes);
        }
    }
}