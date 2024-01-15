using Microsoft.AspNetCore.Mvc;

using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;

using NomNomNosh.API.Config.ErrorHandler;
using NomNomNosh.API.Request.RecipeComment;
using NomNomNosh.API.Config.Auth;

using NomNomNosh.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Authorization;
using NomNomNosh.API.Config.Filter;
using NomNomNosh.API.Config.Response;

namespace NomNomNosh.API.Controllers
{
    [Route("api/recipe/{recipe_id}/comment")]
    public class RecipeCommentController : Controller
    {
        private readonly IRecipeCommentService _recipeCommentService;
        private readonly IErrorHandler _errorHandler;
        private readonly IAuthService _authService;
        public RecipeCommentController(IRecipeCommentService recipeCommentService, IErrorHandler errorHandler, IAuthService authService)
        {
            _recipeCommentService = recipeCommentService;
            _errorHandler = errorHandler;
            _authService = authService;
        }

        [HttpPost]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeCommentDto>> CreateRecipeComment(Guid recipe_id, [FromBody] RecipeCommentCreateRequest recipeComment)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return Json(await _recipeCommentService.CreateRecipeComment(member.Member_Id, recipe_id, new RecipeComment
                {
                    RecipeComment_Content = recipeComment.RecipeComment_Content
                }));
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{recipeComment_id}")]
        [HttpDelete]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeCommentDto>> DeleteRecipeComment(Guid recipe_id, Guid recipeComment_id)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeCommentService.DeleteRecipeComment(member.Member_Id, recipe_id, recipeComment_id);
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }
    }
}