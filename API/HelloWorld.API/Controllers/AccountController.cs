using HelloWorld.Application.Interfaces;
using HelloWorld.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public AccountController(IUserService userService,
         ITokenService tokenService, IAccountService accountService)
        {
            _accountService = accountService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var result = await _accountService.Register(registerDto);
            if (!result.Succeeded) return BadRequest();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserAccessTokenDto>> Login(LoginDto loginDto)
        {
            var result = await _accountService.Login(loginDto.UserName, loginDto.Password);
            return Ok(result);
        }
    }
}