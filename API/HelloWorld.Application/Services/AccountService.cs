using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using HelloWorld.Application.Interfaces;
using HelloWorld.Shared.DTO;
using HelloWorld.Domain.Exceptions;
using AutoMapper;

namespace HelloWorld.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository, SignInManager<AppUser> signInManager,
         ITokenService tokenService, IMapper mapper, IUserService userService)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserAccessTokenDto> Login(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (passwordCheck.IsNotAllowed)
            {
                throw new InvalidCredentialsException();
            }

            var result = new UserAccessTokenDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
            return result;
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<AppUser>(registerDto);
            if (await _userService.UserExistsAsync(user.UserName))
            {
                throw new UserExistsException();
            }
            return await _userService.CreateUserAsync(user, registerDto.Password);
        }
    }
}