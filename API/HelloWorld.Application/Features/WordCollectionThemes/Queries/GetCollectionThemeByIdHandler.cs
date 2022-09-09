using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollectionThemes.Queries
{
    public class GetCollectionThemeByIdHandler
        : IRequestHandler<GetCollectionThemeByIdQuery, WordCollectionThemeDto>
    {
        private IMapper _mapper;
        private ICollectionThemeRepository _collectionThemeRepository;

        public GetCollectionThemeByIdHandler(ICollectionThemeRepository collectionThemeRepository, IMapper mapper)
        {
            _collectionThemeRepository = collectionThemeRepository;
            _mapper = mapper;
        }
        public async Task<WordCollectionThemeDto> Handle(GetCollectionThemeByIdQuery request, CancellationToken cancellationToken)
        {
            var theme = await _collectionThemeRepository.GetThemeByIdAsync(request.Id);
            return _mapper.Map<WordCollectionThemeDto>(theme);
        }
    }
}