using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NzWalks.API.Repositories
{
    public class TokenRepositery : ITokenRepositery
    {
        public readonly IConfiguration configuration;
        public TokenRepositery(IConfiguration conguration)
        {
            this.configuration = conguration;
        }

        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            //Create Claim
            var claim = new List<Claim>();

            claim.Add(new Claim(ClaimTypes.Name, user.UserName));

            foreach(var role in roles)
            {
                claim.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claim,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
