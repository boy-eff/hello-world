using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using HelloWorld.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HelloWorld.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;

        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<AppUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_accessor.HttpContext.User);
        }
    }
}