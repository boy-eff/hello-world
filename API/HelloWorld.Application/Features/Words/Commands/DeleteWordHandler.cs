using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Application.Interfaces;
using MediatR;

namespace HelloWorld.Application.Features.Words.Commands
{
    public class DeleteWordHandler : IRequestHandler<DeleteWordCommand, Task>
    {
        private IWordRepository _wordRepository;

        public DeleteWordHandler(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<Task> Handle(DeleteWordCommand request, CancellationToken cancellationToken)
        {
            await _wordRepository.DeleteWordWithoutSavingAsync(request.Id);
            return Task.CompletedTask;
        }
    }
}