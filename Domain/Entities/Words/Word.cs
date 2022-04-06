using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Words
{
    public partial class Word : Base.BaseEntity<int>
    {
        [Required]
        public string Value { get; private set; }
        [Required]
        public string Translation { get; private set; }
    }
}