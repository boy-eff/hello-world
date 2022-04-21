using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTO
{
    public class CreateCollectionDto
    {
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}