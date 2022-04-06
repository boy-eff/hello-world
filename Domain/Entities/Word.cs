using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class Word : Base.BaseEntity
    {
        [Required]
        public string Value { get; private set; }
        [Required]
        public string Translation { get; private set; }
        public int WordCollectionId { get; private set; }
        public WordCollection WordCollection { get; private set; }
        public ICollection<WordDictionary> WordDictionaries { get; private set; }
    }
}