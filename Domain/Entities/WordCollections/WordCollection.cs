using Domain.Entities.Words;

namespace Domain.Entities.WordCollections
{
    public partial class WordCollection : Base.BaseEntity<int>
    {
        private ICollection<Word> _words;
        public ICollection<Word> Words => _words;
        
        public int OwnerId { get; private set; }
    }
}