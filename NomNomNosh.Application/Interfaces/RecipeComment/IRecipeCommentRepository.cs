using NomNomNosh.Application.DTOs;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Interfaces
{
    public interface IRecipeCommentRepository
    {
        Task<RecipeCommentDto> CreateRecipeComment(Guid member_id, Guid recipe_id, RecipeComment recipeComment);
        Task<RecipeCommentDto> DeleteRecipeComment(Guid member_id, Guid recipe_id, Guid recipeComment_id);
    }
}