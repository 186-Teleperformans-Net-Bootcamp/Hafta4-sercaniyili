using System.ComponentModel.DataAnnotations;

namespace Hafta4_Sercanİyili.DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
