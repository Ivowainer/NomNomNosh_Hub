using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IRecipeStepRepository
    {
        Task<RecipeStepDto> CreateRecipeStep(Guid recipe_id, Guid member_id, RecipeStep recipeStep);
        Task<RecipeStepDto> UpdateRecipeStep(Guid recipe_id, Guid member_id, Guid recipeStep_id, RecipeStep recipeStep);
        Task<RecipeStepDto> DeleteRecipeStep(Guid recipe_id, Guid member_id, Guid recipeStep_id);
    }
}