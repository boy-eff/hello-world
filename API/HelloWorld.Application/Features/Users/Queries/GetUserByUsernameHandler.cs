using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Users.Queries
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, UserInfoDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByUsernameHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);
            return _mapper.Map<UserInfoDto>(user);
        }
    }
}