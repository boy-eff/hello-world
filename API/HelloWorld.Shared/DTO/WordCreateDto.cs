using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Shared.DTO
{
    public class WordCreateDto
    {
        public string Value { get; set; }
        public string Translation { get; set; }
        public int WordCollectionId { get; set; }
    }
}