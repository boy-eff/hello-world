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

namespace HelloWorld.API.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        public CollectionService(IUnitOfWork unitOfWork, IMapper mapper,
         UserManager<AppUser> userManager, IUserService userService)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public void AddCollection(CreateCollectionDto collectionDto, int userId)
        {
            var collection = _mapper.Map<WordCollection>(collectionDto);
            collection.OwnerId = userId;    
            _unitOfWork.CollectionRepository.AddCollection(collection);
        }

        public async Task<IEnumerable<CollectionDto>> GetCollectionsAsync()
        {
            var collections = await _unitOfWork.CollectionRepository.GetCollectionsAsync();
            var collectionsDto = _mapper.Map<IEnumerable<WordCollection>, IEnumerable<CollectionDto>>(collections);
            return collectionsDto;
        }
    }
}