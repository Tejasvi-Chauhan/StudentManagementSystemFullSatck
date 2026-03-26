using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystemFullStack.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;

namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            //  Claims banao (token mein kya store hoga)
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.FullName),
                new Claim("email", user.Email),
                new Claim("role", user.Role)
               
            };

            //  Secret key lo appsettings se
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _config.GetValue<string>("JwtSettings:Token")!));

            //  Signing credentials banao
            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha512);

            //  Token banao
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config.GetValue<string>("JwtSettings:Issuer"),
                audience: _config.GetValue<string>("JwtSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(
                    _config.GetValue<double>("JwtSettings:ExpiryHours")),
                signingCredentials: creds
            );

            //  Token string return karo
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
