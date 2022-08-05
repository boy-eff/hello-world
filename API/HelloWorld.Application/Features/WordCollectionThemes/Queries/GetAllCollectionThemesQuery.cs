using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollectionThemes.Queries
{
    public class GetAllCollectionThemesQuery : IRequest<IEnumerable<WordCollectionThemeDto>>
    {
        
    }
}