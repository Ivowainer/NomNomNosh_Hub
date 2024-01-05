using Microsoft.AspNetCore.Mvc;

using NomNomNosh.Domain.Entities;

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
        public async Task<ActionResult<MemberDto>> RegisterMember(Member member)
        {
            try
            {
                return await _memberService.RegisterMember(member);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<MemberDto>> LoginMember(string email, string password)
        {
            try
            {
                return await _memberService.LoginMember(email, password);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

    }
}