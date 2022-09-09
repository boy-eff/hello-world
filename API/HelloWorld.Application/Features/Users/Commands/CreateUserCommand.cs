using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<UserInfoDto>
    {
        public CreateUserCommand(RegisterDto registerDto) 
        {
            this.RegisterDto = registerDto;
   
        }
        public RegisterDto RegisterDto { get; set; }
    }
}