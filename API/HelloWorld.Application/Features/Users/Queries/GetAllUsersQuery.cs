using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserInfoDto>>
    {
        
    }
}