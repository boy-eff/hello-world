using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccessTokenDto> Login(string username, string password);
        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}