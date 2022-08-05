using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Commands
{
    public class CreateCollectionCommand : IRequest<CollectionDto>
    {
        public CreateCollectionCommand(int userId, CollectionCreateDto collectionCreateDto) 
        {
            this.UserId = userId;
            this.CollectionCreateDto = collectionCreateDto;
   
        }
        public CollectionCreateDto CollectionCreateDto { get; }
        public int UserId { get; }
    }
}