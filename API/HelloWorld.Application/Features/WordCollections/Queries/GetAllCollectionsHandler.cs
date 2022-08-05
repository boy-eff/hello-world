using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Queries
{
    public class GetAllCollectionsHandler : IRequestHandler<GetAllCollectionsQuery, IEnumerable<CollectionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;

        public GetAllCollectionsHandler(IMapper mapper, ICollectionRepository collectionRepository)
        {
            _mapper = mapper;
            _collectionRepository = collectionRepository;
        }
        public async Task<IEnumerable<CollectionDto>> Handle(GetAllCollectionsQuery request, CancellationToken cancellationToken)
        {
            var collections = await _collectionRepository.GetCollectionsAsync();
            var collectionsDto = _mapper.Map<IEnumerable<WordCollection>, IEnumerable<CollectionDto>>(collections);
            return collectionsDto;
        }
    }
}