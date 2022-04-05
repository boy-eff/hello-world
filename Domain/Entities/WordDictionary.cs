namespace Domain.Entities
{
    public partial class WordDictionary : Base.BaseEntity
    {
        public int OwnerId { get; private set; }
        public User Owner { get; private set; }
        public ICollection<Word> Words { get; private set; }
    }
}