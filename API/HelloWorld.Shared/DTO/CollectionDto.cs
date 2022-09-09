namespace HelloWorld.Shared.DTO
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThemeName { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public ICollection<WordDto> Words { get; set; }
    }
}