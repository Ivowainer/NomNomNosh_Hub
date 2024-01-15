using NomNomNosh.Application.DTOs;

namespace NomNomNosh.API.Config.Auth
{
    public interface IAuthService
    {
        string GenerateToken(MemberDto member);
    }
}