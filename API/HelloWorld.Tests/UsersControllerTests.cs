using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.Controllers;
using HelloWorld.API.Interfaces;
using HelloWorld.Tests.Builders;
using Moq.AutoMock;
using Xunit;
using FluentAssertions;
using Moq;
using HelloWorld.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Tests
{
    public class UsersControllerTests
    {
        private readonly UsersController _sut;
        private readonly AutoMocker _mocker = new AutoMocker();

        public UsersControllerTests()
        {
            _sut = _mocker.CreateInstance<UsersController>();
        }

        [Fact]
        public async Task GetUsers_ShouldReturn_OkObjectResult_IfUsersExist()
        {
            var users = new List<UserInfoDto>()
            {
                new UserInfoDto() {Id = 1, Username = "danila"},
                new UserInfoDto() {Id = 2, Username = "nikita"},
                new UserInfoDto() {Id = 3, Username = "artem"},
            };

            _mocker.GetMock<IUserService>().Setup(x => x.GetUsersAsync())
                .ReturnsAsync(users);

            var result = await _sut.GetUsers();

            result.Result.As<OkObjectResult>().Should().NotBeNull();

            result.Result.As<OkObjectResult>().Value.As<IEnumerable<UserInfoDto>>().Should().NotBeNullOrEmpty()
            .And.HaveCount(users.Count);
        }

        [Fact]
        public async Task GetUsers_ShouldReturn_NoContent_IfThereAreNoUsers()
        {
            _mocker.GetMock<IUserService>().Setup(x => x.GetUsersAsync())
                .ReturnsAsync(new List<UserInfoDto>());
            
            var result = await _sut.GetUsers();

            result.Result.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async Task GetUserByUsername_ShouldReturn_OkObjectResult_IfUserExists()
        {  
            var user = new UserInfoDto() {Id = 1, Username = "danila"};

            _mocker.GetMock<IUserService>().Setup(x => x.GetUserByUsernameAsync(user.Username))
                .ReturnsAsync(user);

            var result = await _sut.GetUserByUsername(user.Username);

            result.Result.As<OkObjectResult>().Should().NotBeNull();

            result.Result.As<OkObjectResult>().Value.As<UserInfoDto>().Should().NotBeNull()
                .And.BeEquivalentTo(user);
        }

        [Fact]
        public async Task GetUserByUsername_ShouldReturn_NoContent_IfUserDoesNotExist()
        {
            var username = "username";
            _mocker.GetMock<IUserService>().Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>()))
                .ReturnsAsync((UserInfoDto)null);
            
            var result = await _sut.GetUserByUsername(username);

            result.Result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}