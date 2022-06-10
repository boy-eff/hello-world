using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.API.DTO;
using HelloWorld.API.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IUserRepository userRepository,
            IHttpContextAccessor accessor, IPhotoService photoService, IMapper mapper)
        {
            _mapper = mapper;
            _photoService = photoService;
            _accessor = accessor;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<AppUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_accessor.HttpContext.User);
        }

        public async Task AddPhoto(IFormFile file)
        {
            var user = await GetCurrentUser();
            var result = await _photoService.AddPhotoAsync(file);
            if (result.Error != null) return;
            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            await _userRepository.AddPhoto(user, photo);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<UserInfoDto> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            return _mapper.Map<UserInfoDto>(user);
        }

        public async Task<IEnumerable<UserInfoDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<AppUser>, IEnumerable<UserInfoDto>>(users);
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}