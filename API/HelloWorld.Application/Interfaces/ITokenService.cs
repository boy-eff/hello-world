using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}