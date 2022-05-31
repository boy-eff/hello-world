using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.API.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccessTokenDto> Login(string username, string password);
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}