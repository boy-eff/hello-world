using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Queries
{
    public class GetWordByIdQuery : IRequest<WordDto>
    {
        public GetWordByIdQuery(int id) 
        {
            this.Id = id;
   
        }
        public int Id { get; set; }
    }
}