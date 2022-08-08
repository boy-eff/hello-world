using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HelloWorld.Application.Features.Users.Commands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Exceptions;
using HelloWorld.Tests.Builders;
using HelloWorld.Tests.Fakes;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace HelloWorld.Tests.Commands
{
    public class LogInUserHandlerTests
    {
        private readonly LogInUserHandler _sut;
        private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();
        private readonly Mock<FakeSignInManager> _signInManagerMock = new Mock<FakeSignInManager>();
        private readonly Mock<ITokenService> _tokenServiceMock = new Mock<ITokenService>();

        public LogInUserHandlerTests()
        {
            _sut = new LogInUserHandler(_userRepoMock.Object,
                _signInManagerMock.Object, _tokenServiceMock.Object);
        }

        [Fact]
        public async Task ShouldReturnTokenIfCredentialsAreValid()
        {
            var password = "password";
            var token = "token";

            var appUser = UserBuilder.Default()
                .Simple()
                .Build();

            _userRepoMock.Setup(x => x.GetUserByUsername(appUser.UserName))
                .ReturnsAsync(appUser);
            _tokenServiceMock.Setup(x => x.CreateToken(appUser))
                .Returns(token);
            _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, password, false))
                .ReturnsAsync(SignInResult.Success);
            var result = await _sut.Handle(
                new LogInUserCommand(appUser.UserName, password), CancellationToken.None
            );

            Assert.Equal(token, result.Token);
        }

        [Fact]
        public async Task Login_ShouldThrow_InvalidCredentialsException_IfThereAreNoUser()
        {
            var username = "username";
            var password = "password";

            _userRepoMock.Setup(x => x.GetUserByUsername(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            await Assert.ThrowsAsync<InvalidCredentialsException>(() => _sut.Handle(
                new LogInUserCommand(username, password), CancellationToken.None
            ));
        }

        [Fact]
        public async Task Login_ShouldThrow_InvalidCredentialsException_IfPasswordIsInvalid()
        {
            var password = "password";
            
            var appUser = UserBuilder.Default()
                .Simple()
                .Build();

            _userRepoMock.Setup(x => x.GetUserByUsername(appUser.UserName))
                .ReturnsAsync(appUser);
            _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, It.IsAny<string>(), false))
                .ReturnsAsync(SignInResult.NotAllowed);

            await Assert.ThrowsAsync<InvalidCredentialsException>(() => _sut.Handle(
                new LogInUserCommand(appUser.UserName, password), CancellationToken.None
            ));
        }

        //Example of behaviour verification test
        [Fact]
        public async Task Login_ShouldCreateTokenOnce()
        {
            var password = "password";
            var token = "token";
            var appUser = UserBuilder.Default()
                .Simple()
                .Build();

            _userRepoMock.Setup(x => x.GetUserByUsername(appUser.UserName))
                .ReturnsAsync(appUser);
            _tokenServiceMock.Setup(x => x.CreateToken(appUser))
                .Returns(token);
            _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, password, false))
                .ReturnsAsync(SignInResult.Success);
            var result = await _sut.Handle(
                new LogInUserCommand(appUser.UserName, password), CancellationToken.None
            );

            _tokenServiceMock.Verify(x => x.CreateToken(appUser), Times.Once);
        }
    }
}