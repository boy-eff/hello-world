namespace HelloWorld.Domain.Entities
{
    public class WordCollectionReview
    {
        public int Id { get; set; }
        public int WordCollectionId { get; set; }
        public WordCollection Collection { get; set; }
        public string Content { get; set; }
        public DateTime ReviewTime { get; set; } = DateTime.Now;

    }
}