using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Word : Base.BaseEntity
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public string Translation { get; set; }
        public int WordCollectionId { get; set; }
        public WordCollection WordCollection { get; set; }
        public ICollection<WordDictionary> WordDictionaries { get; set; }
    }
}