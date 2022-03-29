using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Entities
{
    public class Collection
    {

        public Collection(ICollection<Word>? words, int ownerId, DataContext? context)
        {
            if (words == null || words.Count == 0)
            {
                throw new NullReferenceException(nameof(words));
            }
            _words = words;

            if (context == null)
            {
                throw new NullReferenceException(nameof(context));
            }
            if (!context.Users.Any(x => x.Id == ownerId))
            {
                throw new Exception("Invalid owner id");
            }

            OwnerId = ownerId;
        }

        private Collection()
        {

        }

        private ICollection<Word>? _words;
        public IEnumerable<Word>? Words => _words?.ToList();
        
        public int OwnerId { get; private set; }
    }
}