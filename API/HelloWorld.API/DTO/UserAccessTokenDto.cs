using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.API.DTO
{
    public class UserAccessTokenDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}