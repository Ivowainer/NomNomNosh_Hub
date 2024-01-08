using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IRecipeRepository
    {
        Task<RecipeDto> CreateRecipe(Guid member_id, Recipe Recipe);
        Task<RecipeDto> UpdateRecipe(Guid recipe_id);
        Task<RecipeDto> DeleteRecipe(Guid recipe_id);
    }
}