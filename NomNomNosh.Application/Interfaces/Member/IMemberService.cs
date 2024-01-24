using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IMemberService
    {
        public Task<MemberDto> LoginMember(string email, string password);
        public Task<MemberDto> RegisterMember(Member member);
        public Task<Member> GetMember(Guid member_id);
        public Task<ICollection<Recipe>> GetMemberRecipes(Guid member_id);
    }
}