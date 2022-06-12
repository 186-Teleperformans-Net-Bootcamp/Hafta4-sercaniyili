using Microsoft.AspNetCore.Identity;

namespace Hafta4_Sercanİyili.Entities
{
    public class AppUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }

}
