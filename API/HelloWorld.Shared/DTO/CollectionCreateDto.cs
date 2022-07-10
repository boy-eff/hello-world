using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Shared.DTO
{
    public class CollectionCreateDto
    {
        public string Name { get; set; }
        public int ThemeId { get; set; }
        public string Description { get; set; }
    }
}