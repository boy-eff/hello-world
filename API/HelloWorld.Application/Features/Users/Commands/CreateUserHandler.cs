using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Exceptions;
using HelloWorld.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserAccessTokenDto>
    {
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private ITokenService _tokenService;

        public CreateUserHandler(IMapper mapper, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserAccessTokenDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request.RegisterDto);
            if (await _userManager.FindByNameAsync(request.RegisterDto.UserName) != null)
            {
                throw new UserExistsException();
            }
            var identityResult = await _userManager.CreateAsync(user, request.RegisterDto.Password);
            if (identityResult.Errors.Any())
            {
                throw new Exception();
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