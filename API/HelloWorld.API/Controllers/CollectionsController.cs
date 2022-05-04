using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;
using HelloWorld.Domain.Entities;
using HelloWorld.API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Infrastructure.Interfaces;

namespace HelloWorld.API.Controllers
{
    public class CollectionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICollectionService _collectionService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICollectionThemeService _collectionThemeService;
        public CollectionsController(IUnitOfWork unitOfWork, ICollectionService collectionService,
         UserManager<AppUser> userManager, ICollectionThemeService collectionThemeService)
        {
            _collectionThemeService = collectionThemeService;
            _userManager = userManager;
            _collectionService = collectionService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordCollection>>> GetCollections()
        {
            
            var collections = await _collectionService.GetCollectionsAsync();
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
        [HttpGet("themes")]
        public async Task<ActionResult> GetCollectionThemes()
        {
            var themes = await _collectionThemeService.GetCollectionThemesAsync();
            return Ok(themes);
        }
    }
}