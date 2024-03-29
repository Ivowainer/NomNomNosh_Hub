using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IRecipeRepository
    {
        Task<RecipeDto> CreateRecipe(Guid member_id, Recipe Recipe, string username);
        Task<Recipe> GetRecipe(string recipe_slug);
        Task<ICollection<RecipeDto>> GetRecipes();
        Task<RecipeDto> UpdateRecipe(Guid recipe_id, Guid member_id, Recipe recipe);
        Task<RecipeDto> DeleteRecipe(Guid recipe_id, Guid member_id);
    }
}