using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Domain.Entities;
using NomNomNosh.Infrastructure.Data;
using NomNomNosh.Infrastructure.Utils;

namespace NomNomNosh.Infrastructure.Repositories
{
    public class RecipeStepRepository : IRecipeStepRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUtils _utils;
        public RecipeStepRepository(AppDbContext appDbContext, IUtils utils)
        {
            _appDbContext = appDbContext;
            _utils = utils;
        }

        public async Task<RecipeStepDto> CreateRecipeStep(Guid recipe_id, Guid member_id, RecipeStep recipeStep)
        {
            await _utils.GetRecipeIfOwner(recipe_id, member_id);

            recipeStep.Recipe_Id = recipe_id;
            await _appDbContext.RecipeSteps.AddAsync(recipeStep);
            await _appDbContext.SaveChangesAsync();

            return new RecipeStepDto
            {
                Title = recipeStep.Title,
                Content = recipeStep.Content
            };
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