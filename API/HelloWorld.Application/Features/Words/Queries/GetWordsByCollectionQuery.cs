using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Queries
{
    public class GetWordsByCollectionQuery : IRequest<IEnumerable<WordDto>>
    {
        public GetWordsByCollectionQuery(int collectionId) 
        {
            this.CollectionId = collectionId;
   
        }
        public int CollectionId { get; }
    }
}