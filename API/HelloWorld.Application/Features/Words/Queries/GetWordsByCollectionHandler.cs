using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Queries
{
    public class GetWordsByCollectionHandler : IRequestHandler<GetWordsByCollectionQuery, IEnumerable<WordDto>>
    {
        private IMapper _mapper;
        private IWordRepository _wordRepository;

        public GetWordsByCollectionHandler(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WordDto>> Handle(GetWordsByCollectionQuery request, CancellationToken cancellationToken)
        {
            var words = _mapper.Map<IEnumerable<Word>,
                IEnumerable<WordDto>>(await _wordRepository.GetWordsByCollection(request.CollectionId));
            return words;
        }
    }
}