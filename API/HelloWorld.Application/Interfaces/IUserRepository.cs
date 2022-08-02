using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByUsername(string username);
        Task AddPhoto(AppUser user, Photo photo);
    }
}