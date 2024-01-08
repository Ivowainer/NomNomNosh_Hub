using Microsoft.AspNetCore.Mvc;

using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.Request.Member;
using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.API.Config;

namespace NomNomNosh.API.Controllers
{
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IErrorHandler _errorHandler;

        public MemberController(IMemberService memberService, IErrorHandler errorHandler)
        {
            _memberService = memberService;
            _errorHandler = errorHandler;
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> RegisterMember([FromBody] MemberRegistrationRequest member)
        {
            try
            {
                return await _memberService.RegisterMember(new Member
                {
                    Email = member.Email,
                    First_Name = member.First_Name,
                    Last_Name = member.Last_Name,
                    Password = member.Password,
                    Profile_Image = member.Profile_Image,
                    Username = member.Username
                });
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<MemberDto>> LoginMember([FromBody] MemberRegistrationRequest req)
        {
            try
            {
                return await _memberService.LoginMember(req.Email, req.Password);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }
    }
}