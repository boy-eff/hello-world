using HelloWorld.Shared.DTO;
using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Application.Interfaces;
using MediatR;
using HelloWorld.Application.Features.WordCollections.Queries;
using HelloWorld.Application.Features.WordCollections.Commands;
using HelloWorld.Application.Features.Words.Queries;
using HelloWorld.Application.Features.WordCollectionThemes.Queries;
using HelloWorld.Application.Features.Words.Commands;

namespace HelloWorld.API.Controllers
{
    public class CollectionsController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public CollectionsController(IUserService userService, UserManager<AppUser> userManager, IMediator mediator)
        {
            _userService = userService;
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetCollections()
        {
            var query = new GetAllCollectionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetUserCollections(int userId)
        {
            var query = new GetUserCollectionsQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{collectionId}")]
        public async Task<ActionResult<CollectionDto>> GetCollection(int collectionId)
        {
            var query = new GetCollectionByIdQuery(collectionId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddCollection(CollectionCreateDto collectionDto)
        {
            int ownerId = Int32.Parse(_userManager.GetUserId(User));
            var command = new CreateCollectionCommand(ownerId, collectionDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{collectionId}/words")]
        public async Task<IActionResult> UpdateWords(int collectionId, WordDto[] words)
        {
            var command = new UpdateWordsByCollectionCommand(collectionId, words);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{collectionId}/words")]
        public async Task<IActionResult> GetWordsByCollection(int collectionId)
        {
            var query = new GetWordsByCollectionQuery(collectionId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("themes")]
        public async Task<ActionResult> GetCollectionThemes()
        {
            var query = new GetAllCollectionThemesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}