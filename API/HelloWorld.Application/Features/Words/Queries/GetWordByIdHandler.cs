using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Queries
{
    public class GetWordByIdHandler : IRequestHandler<GetWordByIdQuery, WordDto>
    {
        private IWordRepository _wordRepository;
        private IMapper _mapper;

        public GetWordByIdHandler(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        public Task<WordDto> Handle(GetWordByIdQuery request, CancellationToken cancellationToken)
        {
            Word word = _wordRepository.GetWordById(request.Id);
            return Task.Run(() => _mapper.Map<WordDto>(word));
        }
    }
}