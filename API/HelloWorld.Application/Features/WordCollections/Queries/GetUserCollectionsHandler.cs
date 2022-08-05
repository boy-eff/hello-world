using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetUserCollectionsHandler : IRequestHandler<GetUserCollectionsQuery, IEnumerable<CollectionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;
        public GetUserCollectionsHandler(IMapper mapper, ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
            
        }
        public async Task<IEnumerable<CollectionDto>> Handle(GetUserCollectionsQuery request, CancellationToken cancellationToken)
        {
            var collections = await _collectionRepository.GetUserCollectionsAsync(request.UserId);
            var collectionsDto = _mapper.Map<IEnumerable<WordCollection>, IEnumerable<CollectionDto>>(collections);
            return collectionsDto;
        }
    }
}