using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;

using NomNomNosh.Infrastructure.Data;
using NomNomNosh.Infrastructure.Utils;

using Microsoft.EntityFrameworkCore;

namespace NomNomNosh.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IEmailValidator _emailValidator;
        public MemberRepository(AppDbContext appDbContext, IEmailValidator emailValidator)
        {
            _appDbContext = appDbContext;
            _emailValidator = emailValidator;
        }

        public async Task<MemberDto> LoginMember(string email, string password)
        {
            if (!_emailValidator.IsValidEmail(email))
                throw new ArgumentException("The email adress given is wrong");
            if (password.Length <= 5)
                throw new ArgumentException("The password must be at least 6 characters");

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
            throw new NotImplementedException();
        }
    }
}