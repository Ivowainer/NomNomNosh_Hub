using NomNomNosh.Application.DTOs;

namespace NomNomNosh.API.Config.Response.Member
{
    public class MemberLoginResponse
    {
        public MemberDto member { get; set; }
        public string token { get; set; }
    }
}