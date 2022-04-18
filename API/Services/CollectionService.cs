using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Services
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
    }
}