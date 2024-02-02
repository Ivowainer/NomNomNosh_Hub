using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;

using NomNomNosh.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace NomNomNosh.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _appDbContext;
        public MemberRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MemberDto> LoginMember(string email, string password)
        {
            var member = await _appDbContext.Members.FirstOrDefaultAsync(m => m.Email == email);

            if (member == null || !BCrypt.Net.BCrypt.Verify(password, member?.Password))
                throw new UnauthorizedAccessException("Invalid email or password");

            return new MemberDto
            {
                Member_Id = member!.Member_Id,
                Email = member.Email,
                First_Name = member.First_Name,
                Last_Name = member.Last_Name,
                Username = member.Username,
                Profile_Image = member.Profile_Image
            };
        }

        public async Task<MemberDto> RegisterMember(Member member)
        {
            member.Password = BCrypt.Net.BCrypt.HashPassword(member.Password);

            await _appDbContext.Members.AddAsync(member);
            await _appDbContext.SaveChangesAsync();

            return new MemberDto
            {
                Member_Id = member.Member_Id,
                Email = member.Email,
                First_Name = member.First_Name,
                Last_Name = member.Last_Name,
                Profile_Image = member.Profile_Image,
                Username = member.Username,
            };
        }

        public async Task<bool> MemberAlreadyExists(string username, string email)
        {
            return await _appDbContext.Members.AnyAsync(m => m.Username == username || m.Email == email);
        }

        public async Task<Member> GetMember(Guid member_id)
        {
            return _appDbContext.Members.Include(m => m.Recipes).FirstOrDefault(m => m.Member_Id == member_id) ?? throw new InvalidOperationException("Member not found");
        }

        public async Task<ICollection<Recipe>> GetMemberRecipes(Guid member_id)
        {
            return await _appDbContext.Recipes.Where(r => r.Member_Id == member_id).Include(r => r.RecipeSteps).ToListAsync() ?? throw new InvalidOperationException("Member not found");
        }
    }
}