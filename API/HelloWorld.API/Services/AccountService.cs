using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.API.DTO;
using HelloWorld.API.Exceptions;
using HelloWorld.API.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

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
            if (!passwordCheck.Succeeded)
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