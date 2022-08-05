using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollectionThemes.Queries
{
    public class GetCollectionThemeByIdQuery : IRequest<WordCollectionThemeDto>
    {
        public GetCollectionThemeByIdQuery(int id) 
        {
            this.Id = id;
   
        }
        public int Id { get; }
    }
}