using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}