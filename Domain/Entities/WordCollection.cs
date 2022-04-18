namespace Domain.Entities
{
    public class WordCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; }
        public int OwnerId { get; set; }
        public AppUser Owner { get; set; }
    }
}