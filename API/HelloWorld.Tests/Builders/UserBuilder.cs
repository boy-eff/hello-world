using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Tests.Builders
{
    public class UserBuilder : BaseBuilder<AppUser>
    {
        private int _id;
        private string? _name;
        private string? _userName;
        private string? _description;
        private string? _hash;

        public static UserBuilder Default()
        {
            return new UserBuilder();
        }

        public UserBuilder Simple()
        {
            return Default()
                .WithId(1)
                .WithName("Danya")
                .WithUserName("Dan4ik228")
                .WithDescription("Coolest monkey in the jungle")
                .WithPasswordHash("PDFHpf98shdsf9a88dphfa");
        }

        public UserBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public UserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserBuilder WithUserName(string userName)
        {
            _userName = userName;
            return this;
        }

        public UserBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public UserBuilder WithPasswordHash(string hash)
        {
            _hash = hash;
            return this;
        }

        public override AppUser Build()
        {
            return new AppUser()
            {
                Id = _id,
                Name = _name,
                UserName = _userName,
                Description = _description,
                PasswordHash = _hash
            };
        }
    }
}