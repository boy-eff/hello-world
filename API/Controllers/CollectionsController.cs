using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class CollectionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICollectionService _collectionService;
        private readonly UserManager<AppUser> _userManager;
        public CollectionsController(IUnitOfWork unitOfWork, ICollectionService collectionService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _collectionService = collectionService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordCollection>>> GetCollections()
        {
            
            var collections = await _unitOfWork.CollectionRepository.GetCollectionsAsync();
            return Ok(collections);
        }

        [HttpPost]
        public async Task<ActionResult> AddCollection(CreateCollectionDto collectionDto)
        {
            int ownerId = Int32.Parse(_userManager.GetUserId(User));
            _collectionService.AddCollection(collectionDto, ownerId);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}