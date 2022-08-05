using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetCollectionByIdQuery : IRequest<CollectionDto>
    {
        public GetCollectionByIdQuery(int id) 
        {
            Id = id;
   
        }
        public int Id { get; }

        
    }
}