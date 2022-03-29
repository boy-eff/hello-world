using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;

namespace api.Entities
{
    public class Dictionary
    {

        public Dictionary(int ownerId, ICollection<Word>? words, DataContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException(nameof(context));
            }
            if (!context.Users.Any(u => u.Id == ownerId))
            {
                throw new Exception("Invalid owner id");
            }
            OwnerId = ownerId;

            if (words == null)
            {
                throw new NullReferenceException(nameof(words));
            }

            _words = words;
        }

        private Dictionary()
        {

        }

        public int Id { get; private set; }
        public int OwnerId { get; private set; }
        private ICollection<Word>? _words;
        public IEnumerable<Word>? Words => _words?.ToList();
    }
}