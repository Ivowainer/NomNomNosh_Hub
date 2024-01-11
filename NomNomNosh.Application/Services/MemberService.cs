using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Application.Utils.Interface;
using System.Text.RegularExpressions;

namespace NomNomNosh.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {

            _memberRepository = memberRepository;
        }

        public async Task<MemberDto> LoginMember(string email, string password)
        {
            if (!IsValidEmail(email))
                throw new UnauthorizedAccessException("The email adress given is wrong");
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Cannot be null the Emila or Password");

            var member = await _memberRepository.LoginMember(email, password);

            return member;
        }

        public async Task<MemberDto> RegisterMember(Member member)
        {
            if (!IsValidEmail(member.Email))
                throw new ArgumentException("The email adress given is wrong");
            if (member.First_Name.Length < 3)
                throw new ArgumentException("The First Name must be at least 2 characters");
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

        public async Task<Member> GetMember(Guid member_id)
        {
            return await _memberRepository.GetMember(member_id);
        }

        // Utils 
        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}