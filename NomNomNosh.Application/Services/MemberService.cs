using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Application.Utils.Interface;

namespace NomNomNosh.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IEmailValidator _emailValidator;

        public MemberService(IMemberRepository memberRepository, IEmailValidator emailValidator)
        {

            _memberRepository = memberRepository;
            _emailValidator = emailValidator;
        }

        public async Task<MemberDto> LoginMember(string email, string password)
        {
            if (!_emailValidator.IsValidEmail(email))
                throw new ArgumentException("The email adress given is wrong");
            if (password.Length <= 5)
                throw new ArgumentException("The password must be at least 6 characters");

            var member = await _memberRepository.LoginMember(email, password);

            return member;
        }

        public Task<MemberDto> RegisterMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}