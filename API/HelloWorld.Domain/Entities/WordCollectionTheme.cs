using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Entities
{
    public class WordCollectionTheme
    {
        public int Id { get; set; }
        public ICollection<WordCollection> WordCollections { get; set; }
        public string Name { get; set; }
    }
}