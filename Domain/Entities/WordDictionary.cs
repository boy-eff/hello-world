namespace Domain.Entities
{
    public class WordDictionary
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public ICollection<WordToWordDictionary> Words { get; set; }
    }
}