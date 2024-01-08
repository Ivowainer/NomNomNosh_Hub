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
                throw new ArgumentException("The title of the recipe step must be at least 6 characters");
            if (recipeStep.Content.Length < 10)
                throw new ArgumentException("The title of the content must be at least 10 characters");

            return await _recipeStepRepository.CreateRecipeStep(recipe_id, member_id, recipeStep);
        }

        public Task<RecipeStepDto> DeleteRecipeStep(Guid recipe_id, Guid member_id, RecipeStep recipeStep)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeStepDto> UpdateRecipeStep(Guid recipe_id, Guid member_id, RecipeStep recipeStep)
        {
            throw new NotImplementedException();
        }
    }
}