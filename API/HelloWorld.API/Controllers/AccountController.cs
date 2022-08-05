using HelloWorld.Application.Features.Users.Commands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public AccountController(IUserService userService,
         ITokenService tokenService, IMediator mediator)
        {
            _mediator = mediator;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var command = new CreateUserCommand(registerDto);
            var result = await _mediator.Send(command);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserAccessTokenDto>> Login(LoginDto loginDto)
        {
            var command = new LogInUserCommand(loginDto.UserName, loginDto.Password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}