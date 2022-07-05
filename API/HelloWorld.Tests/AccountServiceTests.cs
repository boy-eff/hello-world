using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.API.Exceptions;
using HelloWorld.API.Interfaces;
using HelloWorld.API.Services;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;
using HelloWorld.Shared.DTO;
using HelloWorld.Tests.Fakes;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace HelloWorld.Tests;

public class AccountServiceTests
{
    private readonly AccountService _sut;
    private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();
    private readonly Mock<FakeSignInManager> _signInManagerMock = new Mock<FakeSignInManager>();
    private readonly Mock<ITokenService> _tokenServiceMock = new Mock<ITokenService>();
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
    private readonly Mock<IUserService> _userServiceMock = new Mock<IUserService>();


    public AccountServiceTests()
    {
        _sut = new AccountService(_userRepoMock.Object, _signInManagerMock.Object,
            _tokenServiceMock.Object, _mapperMock.Object, _userServiceMock.Object);
    }

    [Fact]
    public async Task Login_ShouldReturnTokenIfCredentialsAreValid()
    {
        var username = "username";
        var password = "password";
        var id = 1;
        var token = "token";
        var appUser = new AppUser()
        {
            Id = id,
            UserName = "username"
        };

        _userRepoMock.Setup(x => x.GetUserByUsername(username))
            .ReturnsAsync(appUser);
        _tokenServiceMock.Setup(x => x.CreateToken(appUser))
            .Returns(token);
        _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, password, false))
            .ReturnsAsync(SignInResult.Success);
        var result = await _sut.Login(username, password);

        Assert.Equal(token, result.Token);
    }

    [Fact]
    public async Task Login_ShouldThrow_InvalidCredentialsException_IfThereAreNoUser()
    {
        var username = "username";
        var password = "password";

        _userRepoMock.Setup(x => x.GetUserByUsername(It.IsAny<string>()))
            .ReturnsAsync(() => null);

        await Assert.ThrowsAsync<InvalidCredentialsException>(() => _sut.Login(username, password));
    }

     [Fact]
    public async Task Login_ShouldThrow_InvalidCredentialsException_IfPasswordIsInvalid()
    {
        var username = "username";
        var password = "password";
        var id = 1;
        var appUser = new AppUser()
        {
            Id = id,
            UserName = "username"
        };

        _userRepoMock.Setup(x => x.GetUserByUsername(username))
            .ReturnsAsync(appUser);
        _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, It.IsAny<string>(), false))
            .ReturnsAsync(SignInResult.NotAllowed);

        await Assert.ThrowsAsync<InvalidCredentialsException>(() => _sut.Login(username, password));
    }

    //Example of behaviour verification test
    [Fact]
    public async Task Login_ShouldCreateTokenOnce()
    {
        var username = "username";
        var password = "password";
        var id = 1;
        var token = "token";
        var appUser = new AppUser()
        {
            Id = id,
            UserName = "username"
        };

        _userRepoMock.Setup(x => x.GetUserByUsername(username))
            .ReturnsAsync(appUser);
        _tokenServiceMock.Setup(x => x.CreateToken(appUser))
            .Returns(token);
        _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, password, false))
            .ReturnsAsync(SignInResult.Success);
        var result = await _sut.Login(username, password);

        _tokenServiceMock.Verify(x => x.CreateToken(appUser), Times.Once);
    }

    [Fact]
    public async Task Register_ShouldReturnOkIfNoUserExists()
    {
        var registerDto = new RegisterDto()
        {
            UserName = "username",
            Password = "password"
        };
        var appUser = new AppUser()
        {
            UserName = "username"
        };
        _mapperMock.Setup(x => x.Map<AppUser>(registerDto))
            .Returns(appUser);
        _userServiceMock.Setup(x => x.CreateUserAsync(appUser, registerDto.Password))
            .ReturnsAsync(IdentityResult.Success);
    }

    [Fact]
    public async Task Register_ShouldThrow_UserExistsException_IfUserExists()
    {
        var registerDto = new RegisterDto();
        _mapperMock.Setup(x => x.Map<AppUser>(It.IsAny<RegisterDto>()))
            .Throws<UserExistsException>();

        await Assert.ThrowsAsync<UserExistsException>(() => _sut.Register(registerDto));
    }
}
