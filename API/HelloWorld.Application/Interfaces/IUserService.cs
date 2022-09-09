using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> GetCurrentUser();
    }
}