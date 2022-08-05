using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using MediatR;

namespace HelloWorld.Application.Features.WordCollectionThemes.Queries
{
    public class GetAllCollectionThemesQuery : IRequest<IEnumerable<WordCollectionThemeDto>>
    {
        
    }
}