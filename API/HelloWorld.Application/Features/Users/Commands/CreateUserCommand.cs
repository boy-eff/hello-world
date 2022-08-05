using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;
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