using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Services
{
    public class RecipeCommentService : IRecipeCommentService
    {
        private readonly IRecipeCommentRepository _recipeCommentRepository;
        public RecipeCommentService(IRecipeCommentRepository recipeCommentRepository)
        {
            _recipeCommentRepository = recipeCommentRepository;
        }

        public async Task<RecipeCommentDto> CreateRecipeComment(Guid member_id, Guid recipe_id, RecipeComment recipeComment)
        {
            return await _recipeCommentRepository.CreateRecipeComment(member_id, recipe_id, recipeComment);
        }

        public async Task<RecipeCommentDto> DeleteRecipeComment(Guid member_id, Guid recipe_id, Guid recipeComment_id)
        {
            return await _recipeCommentRepository.DeleteRecipeComment(member_id, recipe_id, recipeComment_id);
        }
    }
}