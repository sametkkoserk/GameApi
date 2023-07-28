using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string userName { get; set; }
        public string? fullName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        public string password { get; set; }
    }
}
