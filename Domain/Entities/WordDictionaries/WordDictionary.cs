using System.ComponentModel.DataAnnotations;
using Domain.Entities.Words;

namespace Domain.Entities.WordDictionaries
{
    public partial class WordDictionary : Base.BaseEntity<int>
    {
        [Required]
        public int OwnerId { get; private set; }
        private ICollection<Word> _words;
        public ICollection<Word> Words => _words;
    }
}