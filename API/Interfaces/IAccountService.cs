using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using Microsoft.AspNetCore.Identity;

namespace API.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> Login(string username, string password);
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}