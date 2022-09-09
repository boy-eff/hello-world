using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Shared.DTO;
using HelloWorld.Application.Interfaces;
using HelloWorld.Application.Features.Users.Queries;
using MediatR;
using HelloWorld.Application.Features.Users.Commands;

namespace HelloWorld.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IPhotoService _photoService;
        private readonly IMediator _mediator;
        public UsersController(IUserService userService, IPhotoService photoService, IMediator mediator)
        {
            _photoService = photoService;
            _userService = userService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserInfoDto>> GetUserByUsername(string username)
        {
            var query = new GetUserByUsernameQuery(username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("photo")]
        public async Task<ActionResult> AddPhoto(IFormFile file)
        {
            var command = new UpdateUserPhotoCommand(file);
            var result = await _mediator.Send(command);
            return Ok();
        }
    }
}