using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Exceptions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AccountService(IUnitOfWork unitOfWork, SignInManager<AppUser> signInManager,
         ITokenService tokenService, IMapper mapper, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Login(string username, string password)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!passwordCheck.Succeeded)
            {
                throw new InvalidCredentialsException();
            }

            var result = new UserDto
            {
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