using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using HelloWorld.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace HelloWorld.Application.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> GetCurrentUser();
    }
}