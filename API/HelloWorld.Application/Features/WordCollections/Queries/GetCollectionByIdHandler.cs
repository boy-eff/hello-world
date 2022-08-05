using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetCollectionByIdHandler : IRequestHandler<GetCollectionByIdQuery, CollectionDto>
    {
        private ICollectionRepository _collectionRepository;
        private IMapper _mapper;

        public GetCollectionByIdHandler(ICollectionRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }
        public async Task<CollectionDto> Handle(GetCollectionByIdQuery request, CancellationToken cancellationToken)
        {
            var collection = await _collectionRepository.GetWordCollectionAsync(request.Id);
            var dto = _mapper.Map<CollectionDto>(collection);
            return dto;
        }
    }
}