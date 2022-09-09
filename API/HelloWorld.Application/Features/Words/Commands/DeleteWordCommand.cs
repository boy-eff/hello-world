using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HelloWorld.Application.Features.Words.Commands
{
    public class DeleteWordCommand : IRequest<Task>
    {
        public int Id { get; set; }
    }
}