using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Exceptions;
using HelloWorld.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class LogInUserHandler : IRequestHandler<LogInUserCommand, UserAccessTokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public LogInUserHandler(IUserRepository userRepository,
            SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserAccessTokenDto> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (passwordCheck.IsNotAllowed)
            {
                throw new InvalidCredentialsException();
            }

            var result = new UserAccessTokenDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
            return result;
        }
    }
}