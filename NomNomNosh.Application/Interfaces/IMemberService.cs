using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IMemberService
    {
        public Task<MemberDto> LoginMember(string email, string password);
        public Task<MemberDto> RegisterMember(Member member);
    }
}