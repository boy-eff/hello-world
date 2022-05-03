using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;

namespace HelloWorld.API.Interfaces
{
    public interface ICollectionThemeService
    {
        Task<IEnumerable<WordCollectionThemeDto>> GetCollectionThemesAsync();
    }
}