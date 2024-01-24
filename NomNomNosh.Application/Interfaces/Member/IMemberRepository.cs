using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<MemberDto> LoginMember(string email, string password);
        Task<MemberDto> RegisterMember(Member member);
        public Task<Member> GetMember(Guid member_id);
        public Task<ICollection<Recipe>> GetMemberRecipes(Guid member_id);
        Task<bool> MemberAlreadyExists(string username, string email);
    }
}