using Microsoft.AspNetCore.Mvc;

using NomNomNosh.Domain.Entities;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;

using NomNomNosh.API.Request.Member;
using NomNomNosh.API.Config.ErrorHandler;

using Microsoft.AspNetCore.Authentication;
using NomNomNosh.API.Config.Response.Member;
using NomNomNosh.API.Config.Auth;

namespace NomNomNosh.API.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IErrorHandler _errorHandler;
        private readonly IAuthService _authService;

        public MemberController(IMemberService memberService, IErrorHandler errorHandler, IAuthService authService)
        {
            _memberService = memberService;
            _errorHandler = errorHandler;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<MemberLoginResponse>> RegisterMember([FromBody] MemberRegistrationRequest member)
        {
            try
            {

                var newMember = await _memberService.RegisterMember(new Member
                {
                    Email = member.Email,
                    First_Name = member.First_Name,
                    Last_Name = member.Last_Name,
                    Password = member.Password,
                    Profile_Image = member.Profile_Image!,
                    Username = member.Username
                });

                var token = _authService.GenerateToken(newMember);

                return new MemberLoginResponse
                {
                    member = newMember,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<MemberLoginResponse>> LoginMember([FromBody] MemberLoginRequest req)
        {
            try
            {
                var member = await _memberService.LoginMember(req.Email, req.Password);
                var token = _authService.GenerateToken(member);

                return new MemberLoginResponse
                {
                    member = member,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{member_id}")]
        [HttpGet]
        public async Task<ActionResult<Member>> GetMember(Guid member_id)
        {
            try
            {
                return await _memberService.GetMember(member_id);
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{member_id}/recipe")]
        [HttpGet]
        public async Task<ActionResult<ICollection<Recipe>>> GetMemberRecipes(Guid member_id)
        {
            try
            {
                return Ok(await _memberService.GetMemberRecipes(member_id));
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }
    }
}