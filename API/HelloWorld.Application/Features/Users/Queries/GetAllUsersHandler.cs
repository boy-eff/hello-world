using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Users.Queries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserInfoDto>>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public GetAllUsersHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserInfoDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();
            return _mapper.Map<IEnumerable<AppUser>, IEnumerable<UserInfoDto>>(users);
        }
    }
}