using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.API.DTO
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThemeId { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public ICollection<WordDto> Words { get; set; }
    }
}