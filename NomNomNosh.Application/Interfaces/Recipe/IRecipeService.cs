using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> CreateRecipe(Guid member_id, Recipe recipe);
        Task<Recipe> GetRecipe(Guid recipe_id);
        Task<RecipeDto> UpdateRecipe(Guid recipe_id, Guid member_id, Recipe recipe);
        Task<RecipeDto> DeleteRecipe(Guid recipe_id, Guid member_id);
    }
}