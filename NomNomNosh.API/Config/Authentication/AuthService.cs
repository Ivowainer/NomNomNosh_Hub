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
                new Claim("email", member.Email.ToString()),
                new Claim("id", member.Member_Id.ToString()),
                new Claim("first_name", member.First_Name.ToString()),
                new Claim("last_name", member.Last_Name.ToString()),
                new Claim("profile_image", member.Profile_Image.ToString()),
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

        public MemberDto DecodeToken(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity ?? throw new InvalidOperationException("Identity have an error");

            var usersClaims = identity.Claims;
            Console.WriteLine("===");
            /* Console.WriteLine(httpContext.Request.Headers.Authorization); */
            foreach (Claim claim in usersClaims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }
            Console.WriteLine("===");

            return new MemberDto
            {
                Member_Id = Guid.Parse(usersClaims.FirstOrDefault(c => c.Type == "id")!.Value),
                Username = usersClaims.FirstOrDefault(c => c.Type == "username")!.Value,
                Email = usersClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)!.Value,
                First_Name = usersClaims.FirstOrDefault(c => c.Type == "first_name")!.Value,
                Last_Name = usersClaims.FirstOrDefault(c => c.Type == "last_name")!.Value,
                Profile_Image = usersClaims.FirstOrDefault(c => c.Type == "profile_image")!.Value
            };
        }
    }
}