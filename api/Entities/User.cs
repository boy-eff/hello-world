using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class User
    {
        public User(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        private User()
        {
        }

        public int Id { get; private set; }
        public string? UserName { get; private set; }
        public string? Password { get; private set; }
    }
}