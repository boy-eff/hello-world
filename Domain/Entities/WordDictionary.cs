namespace Domain.Entities
{
    public class WordDictionary : Base.BaseEntity
    {
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}