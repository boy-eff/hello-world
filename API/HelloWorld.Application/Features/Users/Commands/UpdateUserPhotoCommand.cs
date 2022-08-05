using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HelloWorld.Application.Features.Users.Commands
{
    public class UpdateUserPhotoCommand : IRequest<Task>
    {
        public UpdateUserPhotoCommand(IFormFile file) 
        {
            this.File = file;
        }
        public IFormFile File { get; set; }
    }
}