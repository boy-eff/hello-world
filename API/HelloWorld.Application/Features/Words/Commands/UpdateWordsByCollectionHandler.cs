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
    public class UpdateWordsByCollectionHandler
        : IRequestHandler<UpdateWordsByCollectionCommand, IEnumerable<WordDto>>
    {
        private readonly IWordRepository _wordRepository;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public UpdateWordsByCollectionHandler(IWordRepository wordRepository,
            ICollectionRepository collectionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
            _collectionRepository = collectionRepository;
        }
        public async Task<IEnumerable<WordDto>> Handle(UpdateWordsByCollectionCommand request, CancellationToken cancellationToken)
        {
            foreach (var wordDto in request.Words)
            {
                if (wordDto.IsDeleted && wordDto.Id != null)
                {
                    await _wordRepository.DeleteWordWithoutSavingAsync(wordDto.Id.GetValueOrDefault());
                }
                else if (wordDto.Id != null)
                {
                    request.Words.Where(word => word.Id != null && !word.IsDeleted);
                }
                else if (!wordDto.IsDeleted)
                {
                    var word = _mapper.Map<Word>(wordDto);
                    await _wordRepository.AddWordWithoutSavingAsync(word);
                }
            }

            await _collectionRepository.SaveChangesAsync();
            return request.Words;
        }
    }
}