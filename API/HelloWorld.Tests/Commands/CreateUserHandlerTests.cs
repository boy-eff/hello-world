using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using HelloWorld.Application.Features.Users.Commands;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Exceptions;
using HelloWorld.Shared.DTO;
using HelloWorld.Tests.Builders;
using HelloWorld.Tests.Fakes;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace HelloWorld.Tests.Commands
{
    public class CreateUserHandlerTests
    {
        private readonly CreateUserHandler _sut;
        private readonly Mock<FakeUserManager> _userManagerMock = new Mock<FakeUserManager>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<ITokenService> _tokenService = new Mock<ITokenService>();

        public CreateUserHandlerTests()
        {
            _sut = new CreateUserHandler(_mapperMock.Object,
                _userManagerMock.Object, _tokenService.Object);
        }

        [Fact]
        public async Task ShouldReturnCreatedUser()
        {
            var registerDto = UserBuilder.Default()
                .Simple()
                .BuildAsRegisterDto();

            var userInfo = UserBuilder.Default()
                .Simple()
                .BuildAsUserInfoDto();
            
            var appUser = UserBuilder.Default()
                .Simple()
                .Build();
            
            var token = "token";
                
            _mapperMock.Setup(x => x.Map<AppUser>(registerDto))
                .Returns(appUser);
            
            _mapperMock.Setup(x => x.Map<UserInfoDto>(appUser))
                .Returns(userInfo);

            _userManagerMock.Setup(x => x.FindByNameAsync(registerDto.UserName))
                .ReturnsAsync((AppUser)null);
            
            _userManagerMock.Setup(x => x.CreateAsync(appUser, registerDto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _tokenService.Setup(x => x.CreateToken(appUser))
                .Returns(token);
            
            var result = await _sut.Handle(new CreateUserCommand(registerDto), CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().Be(userInfo.Id);
            result.UserName.Should().Be(userInfo.Username);
            result.Token.Should().Be(token);
        }
    
        [Fact]
        public async Task ShouldThrow_UserExistsException_IfUserExists()
        {            
            var registerDto = UserBuilder.Default()
                .Simple()
                .BuildAsRegisterDto();

            var userInfo = UserBuilder.Default()
                .Simple()
                .BuildAsUserInfoDto();
            
            var appUser = UserBuilder.Default()
                .Simple()
                .Build();
                
            _mapperMock.Setup(x => x.Map<AppUser>(registerDto))
                .Returns(appUser);
            
            _mapperMock.Setup(x => x.Map<UserInfoDto>(appUser))
                .Returns(userInfo);

            _userManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(appUser);

            await Assert.ThrowsAsync<UserExistsException>(() => _sut.Handle(
                new CreateUserCommand(registerDto), CancellationToken.None
            ));
        }
    }
}