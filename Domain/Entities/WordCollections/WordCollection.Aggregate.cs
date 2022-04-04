using Domain.Entities.Words;

namespace Domain.Entities.WordCollections
{
    public partial class WordCollection
    {
        public WordCollection(ICollection<Word> words, int ownerId)
        {
            _words = words;
            OwnerId = ownerId;
        }
    }
}