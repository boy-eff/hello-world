using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Domain.Entities
{
    public class Word
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Translation { get; set; }
        public int WordCollectionId { get; set; }
        public WordCollection WordCollection { get; set; }
        public ICollection<WordToWordDictionary> WordDictionaries { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}