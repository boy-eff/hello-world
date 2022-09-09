using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetAllCollectionsQuery : IRequest<IEnumerable<CollectionDto>>
    {
        
    }
}