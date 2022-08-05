using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetAllCollectionsQuery : IRequest<IEnumerable<CollectionDto>>
    {
        
    }
}