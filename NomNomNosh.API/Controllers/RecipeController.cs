using Microsoft.AspNetCore.Mvc;
using NomNomNosh.API.Config.ErrorHandler;
using NomNomNosh.Application.DTOs;

using NomNomNosh.API.Config.Filter;

using NomNomNosh.Application.Interfaces;
using NomNomNosh.API.Request.Recipe;
using NomNomNosh.Domain.Entities;
using NomNomNosh.API.Config.Auth;

namespace NomNomNosh.API.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IErrorHandler _errorHandler;
        private readonly IAuthService _authService;
        public RecipeController(IRecipeService recipeService, IErrorHandler errorHandler, IAuthService authService)
        {
            _recipeService = recipeService;
            _errorHandler = errorHandler;
            _authService = authService;
        }

        [HttpPost]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeDto>> CreateRecipe([FromBody] RecipeCreateRequest recipe)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeService.CreateRecipe(member.Member_Id, new Recipe
                {
                    Title = recipe.Title,
                    Main_Image = recipe.Main_Image,
                    Description = recipe.Description
                });
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<RecipeDto>>> GetRecipes()
        {
            try
            {
                return Ok(await _recipeService.GetRecipes());
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{recipe_id}")]
        [HttpGet]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid recipe_id)
        {
            try
            {
                return await _recipeService.GetRecipe(recipe_id);
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{recipe_id}")]
        [HttpPut]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeDto>> UpdateRecipe(Guid recipe_id, [FromBody] RecipeUpdateRequest recipe)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeService.UpdateRecipe(recipe_id, member.Member_Id, new Recipe
                {
                    Title = recipe.Title,
                    Description = recipe.Description,
                    Main_Image = recipe.Main_Image
                });
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }

        [Route("{recipe_id}")]
        [HttpDelete]
        [TypeFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<RecipeDto>> DeleteRecipe(Guid recipe_id)
        {
            try
            {
                var member = _authService.DecodeToken(HttpContext);

                return await _recipeService.DeleteRecipe(recipe_id, member.Member_Id);
            }
            catch (Exception ex)
            {
                return Json(_errorHandler.HandleError(ex));
            }
        }
    }
}