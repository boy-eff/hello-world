using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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