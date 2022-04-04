using Domain.Entities.Words;

namespace Domain.Entities.WordDictionaries
{
    public partial class WordDictionary
    {
        public WordDictionary(int ownerId, ICollection<Word>? words)
        {
            OwnerId = ownerId;

            if (words == null)
            {
                throw new NullReferenceException(nameof(words));
            }

            _words = words;
        }
    }
}