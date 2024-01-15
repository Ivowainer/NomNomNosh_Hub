using Microsoft.AspNetCore.Mvc;
using NomNomNosh.API.Config.ErrorHandler;
using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.API.Request.RecipeStep;
using NomNomNosh.Domain.Entities;
using NomNomNosh.API.Config.Filter;
using NomNomNosh.API.Config.Auth;

namespace NomNomNosh.API.Controllers
{
    [Route("api/recipe/{recipe_id}/step")]
    public class RecipeStepController : Controller
    {
        private readonly IRecipeStepService _recipeStepService;
        private readonly IErrorHandler _errorHandler;
        private readonly IAuthService _authService;
        public RecipeStepController(IRecipeStepService recipeStepService, IErrorHandler errorHandler, IAuthService authService)
        {
            _recipeStepService = recipeStepService;
            _errorHandler = errorHandler;
            _authService = authService;
        }

        [HttpPost]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeStepDto>> CreateRecipeStep(Guid recipe_id, [FromBody] RecipeStepCreateRequest recipeStep)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeStepService.CreateRecipeStep(recipe_id, member.Member_Id, new RecipeStep
                {
                    Title = recipeStep.Title,
                    RecipeStep_Content = recipeStep.RecipeStep_Content
                });
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{recipeStep_id}")]
        [HttpPut]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeStepDto>> UpdateRecipeStep(Guid recipe_id, Guid recipeStep_id, [FromBody] RecipeStepUpdateRequest recipeStep)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeStepService.UpdateRecipeStep(recipe_id, member.Member_Id, recipeStep_id, new RecipeStep
                {
                    Title = recipeStep.Title,
                    RecipeStep_Content = recipeStep.RecipeStep_Content
                });
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{recipeStep_id}")]
        [HttpDelete]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeStepDto>> DeleteRecipeStep(Guid recipe_id, Guid recipeStep_id)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeStepService.DeleteRecipeStep(recipe_id, member.Member_Id, recipeStep_id);
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }
    }
}