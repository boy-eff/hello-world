using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<bool> UserExistsAsync(string username);
    }
}