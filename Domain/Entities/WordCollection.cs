namespace Domain.Entities
{
    public partial class WordCollection : Base.BaseEntity
    {
        public ICollection<Word> Words { get; private set; }
        
        public int OwnerId { get; private set; }
        public User Owner { get; private set; }
    }
}