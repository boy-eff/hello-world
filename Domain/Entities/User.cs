using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : Base.BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public WordDictionary WordDictionary { get; set; }
        public ICollection<WordCollection> WordCollections { get; set; }
    }
}