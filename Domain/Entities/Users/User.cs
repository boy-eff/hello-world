using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Users
{
    public partial class User : Base.BaseEntity<int>
    {
        [Required]
        public string UserName { get; private set; }
        [Required]
        public string Password { get; private set; }
    }
}