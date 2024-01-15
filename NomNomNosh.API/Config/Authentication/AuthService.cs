using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using NomNomNosh.Application.DTOs;

using NomNomNosh.API.Config.Auth;

namespace NomNomNosh.API.Config.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(MemberDto member)
        {
            // Key
            if (_config["JwtSettings:Key"].IsNullOrEmpty())
                throw new InvalidOperationException("JwtSettings is not valid");

            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!);
            var keySecurity = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(keySecurity, SecurityAlgorithms.HmacSha256);

            // Claims
            var claims = new[]
            {
                new Claim("username", member.Username),
                new Claim("email", member.Email),
                new Claim("id", member.Member_Id.ToString()),
            };

            // Token
            var token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}