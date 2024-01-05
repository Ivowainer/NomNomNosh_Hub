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
                throw new UnauthorizedAccessException("The email adress given is wrong");

            var member = await _memberRepository.LoginMember(email, password);

            return member;
        }

        public async Task<MemberDto> RegisterMember(Member member)
        {
            if (!_emailValidator.IsValidEmail(member.Email))
                throw new ArgumentException("The email adress given is wrong");
            if (member.Last_Name.Length <= 3)
                throw new ArgumentException("The Last Name must be at least 6 characters");
            if (member.Password.Length <= 5)
                throw new ArgumentException("The Password must be at least 6 characters");
            member.Profile_Image ??= "https://img.freepik.com/free-vector/illustration-user-avatar-icon_53876-5907.jpg?w=740&t=st=1704294997~exp=1704295597~hmac=dfd96f01386981955314f5bdf9ecc5b386eb1350fa5c7a38ce2cee178a0c3575";

            if (await _memberRepository.MemberAlreadyExists(member.Username, member.Email))
                throw new ArgumentException($"The user {member.Username} already exists");

            var newMember = await _memberRepository.RegisterMember(member);

            return newMember;
        }
    }
}