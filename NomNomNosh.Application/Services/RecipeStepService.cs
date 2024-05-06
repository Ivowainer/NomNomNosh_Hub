using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Services
{
    public class RecipeStepService : IRecipeStepService
    {
        private readonly IRecipeStepRepository _recipeStepRepository;
        public RecipeStepService(IRecipeStepRepository recipeStepRepository)
        {
            _recipeStepRepository = recipeStepRepository;
        }

        public async Task<RecipeStepDto> CreateRecipeStep(Guid recipe_id, Guid member_id, RecipeStep recipeStep)
        {
            if (recipeStep.Title.Length < 6)
                throw new ArgumentException("Recipe step title must contain at least 6 characters");
            if (recipeStep.RecipeStep_Content.Length < 10)
                throw new ArgumentException("Content title must contain at least 10 characters");

            return await _recipeStepRepository.CreateRecipeStep(recipe_id, member_id, recipeStep);
        }

        public async Task<RecipeStepDto> UpdateRecipeStep(Guid recipe_id, Guid member_id, Guid recipeStep_id, RecipeStep recipeStep)
        {
            if (recipeStep.Title.Length < 6)
                throw new ArgumentException("Recipe step title must contain at least 6 characters");
            if (recipeStep.RecipeStep_Content.Length < 10)
                throw new ArgumentException("Content title must contain at least 10 characters");

            return await _recipeStepRepository.UpdateRecipeStep(recipe_id, member_id, recipeStep_id, recipeStep);
        }

        public async Task<RecipeStepDto> DeleteRecipeStep(Guid recipe_id, Guid member_id, Guid recipeStep_id)
        {
            return await _recipeStepRepository.DeleteRecipeStep(recipe_id, member_id, recipeStep_id);
        }

    }
}