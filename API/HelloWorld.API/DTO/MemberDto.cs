using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.API.DTO
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}