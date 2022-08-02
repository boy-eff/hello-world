using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.API.Services;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Exceptions;
using HelloWorld.Shared.DTO;
using HelloWorld.Tests.Builders;
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
        var result = await _sut.Login(appUser.UserName, password);

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
        var password = "password";
        
        var appUser = UserBuilder.Default()
            .Simple()
            .Build();

        _userRepoMock.Setup(x => x.GetUserByUsername(appUser.UserName))
            .ReturnsAsync(appUser);
        _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(appUser, It.IsAny<string>(), false))
            .ReturnsAsync(SignInResult.NotAllowed);

        await Assert.ThrowsAsync<InvalidCredentialsException>(() => _sut.Login(appUser.UserName, password));
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
        var result = await _sut.Login(appUser.UserName, password);

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
        
        var appUser = UserBuilder.Default()
            .Simple()
            .Build();
            
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
