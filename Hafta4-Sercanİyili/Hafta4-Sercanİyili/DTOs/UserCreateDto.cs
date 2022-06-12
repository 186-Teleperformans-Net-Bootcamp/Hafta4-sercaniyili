using System.ComponentModel.DataAnnotations;

namespace Hafta4_Sercanİyili.DTOs
{
    public class UserCreateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
