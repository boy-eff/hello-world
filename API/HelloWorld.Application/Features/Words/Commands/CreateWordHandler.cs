using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloWorld.Application.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Commands
{
    public class CreateWordHandler : IRequestHandler<CreateWordCommand, WordDto>
    {
        private IMapper _mapper;
        private IWordRepository _wordRepository;

        public CreateWordHandler(IMapper mapper, IWordRepository wordRepository)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
        }
        public async Task<WordDto> Handle(CreateWordCommand request, CancellationToken cancellationToken)
        {
            var word = _mapper.Map<Word>(request.WordDto);
            await _wordRepository.AddWordWithoutSavingAsync(word);
            return request.WordDto;
        }
    }
}