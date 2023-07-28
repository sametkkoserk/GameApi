using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTOs
{
    public class UpdateUserDto
    {
        [Range(1,100)]
        public string? userName { get; set; }
        public string? fullName { get; set; }
        [EmailAddress]
        public string? email { get; set; }
    }
}
