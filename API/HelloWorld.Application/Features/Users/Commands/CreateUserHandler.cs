using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Exceptions;
using HelloWorld.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserInfoDto>
    {
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private IUserService _userService;

        public CreateUserHandler(IMapper mapper, UserManager<AppUser> userManager, IUserService userService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<UserInfoDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request.RegisterDto);
            if (await _userManager.FindByNameAsync(request.RegisterDto.UserName) != null)
            {
                throw new UserExistsException();
            }
            await _userManager.CreateAsync(user, request.RegisterDto.Password);
            return _mapper.Map<UserInfoDto>(user);
        }
    }
}