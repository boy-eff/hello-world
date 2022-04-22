namespace API.Entities
{
    public class WordCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReviewStatus { get; set; } = "Local";
        public ICollection<Word> Words { get; set; }
        public int OwnerId { get; set; }
        public ICollection<WordCollectionReview> Reviews { get; set; }
        public AppUser Owner { get; set; }

    }
}