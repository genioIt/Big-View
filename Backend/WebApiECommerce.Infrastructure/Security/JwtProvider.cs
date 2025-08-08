using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Infrastructure.Security
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _config;

        public JwtProvider(IConfiguration config) 
        { 
            _config = config; 
        }
        public string GenerateToken(string email, IEnumerable<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

           var token = new JwtSecurityToken(
               issuer: _config["JwtSettings:Issuer"],
               audience: _config["JwtSettings:Audience"],
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["JwtSettings:ExpirationInMinutes"]!)),
               signingCredentials: creds
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
