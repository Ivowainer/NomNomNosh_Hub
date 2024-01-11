using Microsoft.AspNetCore.Mvc;
using NomNomNosh.API.Config;
using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Application.Request.RecipeComment;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.API.Controllers
{
    [Route("api/member/{member_id}/recipe/{recipe_id}/comment")]
    public class RecipeCommentController : Controller
    {
        private readonly IRecipeCommentService _recipeCommentService;
        private readonly IErrorHandler _errorHandler;
        public RecipeCommentController(IRecipeCommentService recipeCommentService, IErrorHandler errorHandler)
        {
            _recipeCommentService = recipeCommentService;
            _errorHandler = errorHandler;
        }

        [HttpPost]
        public async Task<ActionResult<RecipeCommentDto>> CreateRecipeComment(Guid member_id, Guid recipe_id, [FromBody] RecipeCommentCreateRequest recipeComment)
        {
            try
            {
                return await _recipeCommentService.CreateRecipeComment(member_id, recipe_id, new RecipeComment
                {
                    RecipeComment_Content = recipeComment.RecipeComment_Content
                });
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [Route("{recipeComment_id}")]
        [HttpDelete]
        public async Task<ActionResult<RecipeCommentDto>> CreateRecipeComment(Guid member_id, Guid recipe_id, Guid recipeComment_id)
        {
            try
            {
                return await _recipeCommentService.DeleteRecipeComment(member_id, recipe_id, recipeComment_id);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }
    }
}