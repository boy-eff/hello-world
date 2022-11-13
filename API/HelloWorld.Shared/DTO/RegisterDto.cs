using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Shared.DTO
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password length should be between 6 and 16 symbols")]
        public string Password { get; set; }

    }
}