using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string email{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
