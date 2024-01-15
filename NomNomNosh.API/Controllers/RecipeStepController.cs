using Microsoft.AspNetCore.Mvc;
using NomNomNosh.API.Config.ErrorHandler;
using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.API.Request.RecipeStep;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.API.Controllers
{
    [Route("api/member/{member_id}/recipe/{recipe_id}/step")]
    public class RecipeStepController : Controller
    {
        private readonly IRecipeStepService _recipeStepService;
        private readonly IErrorHandler _errorHandler;
        public RecipeStepController(IRecipeStepService recipeStepService, IErrorHandler errorHandler)
        {
            _recipeStepService = recipeStepService;
            _errorHandler = errorHandler;
        }

        [HttpPost]
        public async Task<ActionResult<RecipeStepDto>> CreateRecipeStep(Guid recipe_id, Guid member_id, [FromBody] RecipeStepCreateRequest recipeStep)
        {
            try
            {
                return await _recipeStepService.CreateRecipeStep(recipe_id, member_id, new RecipeStep
                {
                    Title = recipeStep.Title,
                    RecipeStep_Content = recipeStep.RecipeStep_Content
                });
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [Route("{recipeStep_id}")]
        [HttpPut]
        public async Task<ActionResult<RecipeStepDto>> UpdateRecipeStep(Guid recipe_id, Guid member_id, Guid recipeStep_id, [FromBody] RecipeStepUpdateRequest recipeStep)
        {
            try
            {
                return await _recipeStepService.UpdateRecipeStep(recipe_id, member_id, recipeStep_id, new RecipeStep
                {
                    Title = recipeStep.Title,
                    RecipeStep_Content = recipeStep.RecipeStep_Content
                });
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [Route("{recipeStep_id}")]
        [HttpDelete]
        public async Task<ActionResult<RecipeStepDto>> DeleteRecipeStep(Guid recipe_id, Guid member_id, Guid recipeStep_id)
        {
            try
            {
                return await _recipeStepService.DeleteRecipeStep(recipe_id, member_id, recipeStep_id);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }
    }
}