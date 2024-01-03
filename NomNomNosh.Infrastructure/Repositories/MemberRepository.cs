using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;

using NomNomNosh.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

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

            if (member == null || member.Password != password)
                throw new InvalidOperationException("Invalid email or password");

            return new MemberDto
            {
                Member_Id = member.Member_Id,
                Email = member.Email,
                First_Name = member.First_Name,
                Last_Name = member.Last_Name,
                Username = member.Username,
                Profile_Image = member.Profile_Image
            };
        }

        public async Task<MemberDto> RegisterMember(Member member)
        {
            await _appDbContext.Members.AddAsync(member);

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
    }
}