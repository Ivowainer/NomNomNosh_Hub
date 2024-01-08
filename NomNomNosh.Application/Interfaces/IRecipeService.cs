using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IRecipeService
    {
        public Task<RecipeDto> CreateRecipe(Guid member_id, Recipe recipe);
    }
}