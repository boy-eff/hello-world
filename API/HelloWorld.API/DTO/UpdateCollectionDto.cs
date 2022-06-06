using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.API.DTO
{
    public class UpdateCollectionDto
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int UserId { get; set; }
        public ICollection<WordDto> Words { get; set; }
    }
}