using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelloWorld.API.DTO;
using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.API.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<IEnumerable<MemberDto>> GetUsersAsync();
        Task<bool> UserExistsAsync(string username);
        Task<MemberDto> GetUserByUsernameAsync(string username);
        Task AddPhoto(IFormFile file);
    }
}