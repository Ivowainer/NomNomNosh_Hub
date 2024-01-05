using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<MemberDto> LoginMember(string email, string password);
        Task<MemberDto> RegisterMember(Member member);
        Task<bool> MemberAlreadyExists(string username, string email);
    }
}