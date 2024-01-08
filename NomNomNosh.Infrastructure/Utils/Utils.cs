using NomNomNosh.Application.Utils.Interface;
using NomNomNosh.Domain.Entities;
using NomNomNosh.Infrastructure.Data;

namespace NomNomNosh.Infrastructure.Utils
{
    public class Utils : IUtils
    {
        private readonly AppDbContext _appDbContext;
        public Utils(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Recipe> GetRecipeIfOwner(Guid recipe_id, Guid member_id)
        {
            var recipe = await _appDbContext.Recipes.FindAsync(recipe_id) ?? throw new InvalidOperationException("Recipe not found."); ;

            if (recipe.Member_Id != member_id)
                throw new UnauthorizedAccessException("You are not authorized to edit this recipe.");

            return recipe;
        }
    }
}