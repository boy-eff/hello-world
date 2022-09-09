using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Users.Queries
{
    public class GetUserByUsernameQuery : IRequest<UserInfoDto>
    {
        public GetUserByUsernameQuery(string username) 
        {
            this.Username = username;
   
        }
        public string Username { get; set; }
    }
}