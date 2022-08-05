using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using MediatR;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class UpdateUserPhotoHandler : IRequestHandler<UpdateUserPhotoCommand, Task>
    {
        private IUserService _userService;
        private IPhotoService _photoService;
        private IUserRepository _userRepository;

        public UpdateUserPhotoHandler(IPhotoService photoService, IUserService userService, IUserRepository userRepository)
        {
            _photoService = photoService;
            _userService = userService;
            _userRepository = userRepository;
        }

        public async Task<Task> Handle(UpdateUserPhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUser();
            var result = await _photoService.AddPhotoAsync(request.File);
            if (result.Error != null) return Task.CompletedTask;
            var photo = new Photo()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            await _userRepository.AddPhoto(user, photo);
            return Task.CompletedTask;
        }
    }
}