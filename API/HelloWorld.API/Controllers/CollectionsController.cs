using HelloWorld.API.DTO;
using HelloWorld.Domain.Entities;
using HelloWorld.API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.API.Services;

namespace HelloWorld.API.Controllers
{
    public class CollectionsController : BaseApiController
    {
        private readonly ICollectionService _collectionService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICollectionThemeService _collectionThemeService;
        private readonly IUserService _userService;
        private readonly IWordService _wordService;
        public CollectionsController(ICollectionService collectionService, IUserService userService,
         UserManager<AppUser> userManager, ICollectionThemeService collectionThemeService,
         IWordService wordService)
        {
            _wordService = wordService;
            _userService = userService;
            _collectionThemeService = collectionThemeService;
            _userManager = userManager;
            _collectionService = collectionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetCollections()
        {
            
            var collections = await _collectionService.GetCollectionsAsync();
            return Ok(collections);
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetUserCollections(int userId)
        {
            var collections = await _collectionService.GetUserCollectionsAsync(userId);
            return Ok(collections);
        }

        [HttpGet("{collectionId}")]
        public async Task<ActionResult<CollectionDto>> GetCollection(int collectionId)
        {
            var collection = await _collectionService.GetWordCollectionAsync(collectionId);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<ActionResult> AddCollection(CollectionCreateDto collectionDto)
        {
            int ownerId = Int32.Parse(_userManager.GetUserId(User));
            await _collectionService.AddCollection(collectionDto, ownerId);
            return Ok();
        }

        [HttpPost("{collectionId}/words")]
        public async Task<IActionResult> UpdateWords(int collectionId, WordDto[] words)
        {
            await _collectionService.UpdateWordsAsync(collectionId, words);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCollection(CollectionUpdateDto collectionDto)
        {
            int ownerId = Int32.Parse(_userManager.GetUserId(User));
            if (ownerId != collectionDto.UserId)
            {
                return Unauthorized();
            }
            await _collectionService.UpdateCollectionAsync(collectionDto);
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