using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class User : Base.BaseEntity
    {
        [Required]
        public string UserName { get; private set; }
        [Required]
        public string Password { get; private set; }
        public WordDictionary WordDictionary { get; private set; }
        public ICollection<WordCollection> WordCollections { get; private set; }
    }
}