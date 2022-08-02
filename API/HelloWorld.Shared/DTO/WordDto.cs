namespace HelloWorld.Shared.DTO
{
    public class WordDto
    {
        public int? Id { get; set; }
        public string Value { get; set; }
        public string Translation { get; set; }
        public int WordCollectionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}