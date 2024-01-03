using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<MemberDto> RegisterMember(Member member);
        Task<MemberDto> LoginMember(string email, string password);
    }
}