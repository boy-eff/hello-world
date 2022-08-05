using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollectionThemes.Queries
{
    public class GetAllCollectionThemesHandler 
        : IRequestHandler<GetAllCollectionThemesQuery, IEnumerable<WordCollectionThemeDto>>
    {
        private IMapper _mapper;
        private ICollectionThemeRepository _collectionThemeRepository;

        public GetAllCollectionThemesHandler(ICollectionThemeRepository collectionThemeRepository, IMapper mapper)
        {
            _collectionThemeRepository = collectionThemeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WordCollectionThemeDto>> Handle(GetAllCollectionThemesQuery request, CancellationToken cancellationToken)
        {
            var themes =  await _collectionThemeRepository.GetCollectionThemesAsync();
            return _mapper.Map<IEnumerable<WordCollectionTheme>, IEnumerable<WordCollectionThemeDto>>(themes);
        }
    }
}