using Microsoft.AspNetCore.Mvc;
using NomNomNosh.API.Config;
using NomNomNosh.Application.DTOs;

using NomNomNosh.Application.Interfaces;
using NomNomNosh.Application.Request.Recipe;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.API.Controllers
{
    [Route("[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IErrorHandler _errorHandler;
        public RecipeController(IRecipeService recipeService, IErrorHandler errorHandler)
        {
            _recipeService = recipeService;
            _errorHandler = errorHandler;
        }

        [Route("{member_id}")]
        [HttpPost]
        public async Task<ActionResult<RecipeDto>> CreateRecipe(Guid member_id, [FromBody] RecipeCreateRequest recipe)
        {
            try
            {
                return await _recipeService.CreateRecipe(member_id, new Recipe
                {
                    Title = recipe.Title,
                    Main_Image = recipe.Main_Image,
                    Description = recipe.Description
                });
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }

        [Route("{member_id}/{recipe_id}")]
        [HttpPost]
        public async Task<ActionResult<RecipeDto>> CreateRecipe(Guid member_id, Guid recipe_id)
        {
            try
            {
                return await _recipeService.DeleteRecipe(recipe_id, member_id);
            }
            catch (Exception ex)
            {
                return _errorHandler.HandleError(ex);
            }
        }
    }
}