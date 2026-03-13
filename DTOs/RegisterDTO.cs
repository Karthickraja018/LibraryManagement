using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "User";
    }
}
