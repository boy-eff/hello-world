using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Commands
{
    public class CreateWordCommand : IRequest<WordDto>
    {
        public WordDto WordDto { get; set; }
    }
}