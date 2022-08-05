using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollections.Commands
{
    public class CreateCollectionHandler : IRequestHandler<CreateCollectionCommand, CollectionDto>
    {
        private IMapper _mapper;
        private ICollectionThemeRepository _collectionThemeRepository;
        private ICollectionRepository _collectionRepository;

        public CreateCollectionHandler(ICollectionThemeRepository collectionThemeRepository,
             IMapper mapper, ICollectionRepository collectionRepository)
        {
            _collectionThemeRepository = collectionThemeRepository;
            _mapper = mapper;
            _collectionRepository = collectionRepository;
        }

        public async Task<CollectionDto> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {
            var collectionDto = request.CollectionCreateDto;
            var collection = _mapper.Map<WordCollection>(request.CollectionCreateDto);
            collection.Theme = await _collectionThemeRepository.GetThemeByIdAsync(collectionDto.ThemeId);
            collection.OwnerId = request.UserId;    
            await _collectionRepository.AddCollection(collection);
            return _mapper.Map<CollectionDto>(collection);
        }
    }
}