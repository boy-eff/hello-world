using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Shared.DTO;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Application.Interfaces
{
    public interface ICollectionThemeService
    {
        Task<IEnumerable<WordCollectionThemeDto>> GetCollectionThemesAsync();
        Task<WordCollectionTheme> GetCollectionThemeById(int id);
    }
}