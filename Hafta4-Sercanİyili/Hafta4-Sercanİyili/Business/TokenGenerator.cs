using Hafta4_Sercanİyili.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hafta4_Sercanİyili.Business
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Jwt token üreten metodu yazıyorum
        public string GetToken(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
            };

            var token = new JwtSecurityToken(
           issuer: _configuration["JWT:ValidIssuer"],
           audience: _configuration["JWT:ValidAudience"],
           expires: DateTime.Now.AddHours(1),
           claims: userClaims,
           signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
           );

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt=tokenHandler.WriteToken(token);

            return jwt;      
        }
    }
}
