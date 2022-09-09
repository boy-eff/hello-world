using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class LogInUserCommand : IRequest<UserAccessTokenDto>
    {
        public LogInUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}