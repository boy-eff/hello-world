using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.Words.Commands
{
    public class UpdateWordsByCollectionCommand : IRequest<IEnumerable<WordDto>>
    {
        public UpdateWordsByCollectionCommand(int collectionId, WordDto[] words)
        {
            CollectionId = collectionId;
            Words = words;
        }
        public int CollectionId { get; set; }
        public WordDto[] Words { get; set; }
    }
}