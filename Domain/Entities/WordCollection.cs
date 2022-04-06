namespace Domain.Entities
{
    public class WordCollection : Base.BaseEntity
    {
        public ICollection<Word> Words { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}