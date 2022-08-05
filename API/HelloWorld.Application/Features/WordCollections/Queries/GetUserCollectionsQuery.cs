using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetUserCollectionsQuery : IRequest<IEnumerable<CollectionDto>>
    {
        public GetUserCollectionsQuery(int userId) 
        {
            UserId = userId;
   
        }
        public int UserId { get; }
    }
}