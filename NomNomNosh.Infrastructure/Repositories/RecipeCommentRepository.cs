using Microsoft.EntityFrameworkCore;
using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Domain.Entities;
using NomNomNosh.Infrastructure.Data;
using NomNomNosh.Infrastructure.Utils;

namespace NomNomNosh.Infrastructure.Repositories
{
    public class RecipeCommentRepository : IRecipeCommentRepository
    {
        private readonly IUtils _utils;
        private readonly AppDbContext _appDbContext;
        public RecipeCommentRepository(AppDbContext appDbContext, IUtils utils)
        {
            _utils = utils;
            _appDbContext = appDbContext;
        }

        public async Task<RecipeCommentDto> CreateRecipeComment(Guid member_id, Guid recipe_id, RecipeComment recipeComment)
        {
            if (!await _appDbContext.Recipes.AnyAsync(r => r.Recipe_Id == recipe_id))
                throw new InvalidOperationException("Recipe not found");
            if (!await _appDbContext.Members.AnyAsync(m => m.Member_Id == member_id))
                throw new InvalidOperationException("Member not found");

            recipeComment.RecipeComment_Date = DateTime.Now;
            recipeComment.Member_Id = member_id;
            recipeComment.Recipe_Id = recipe_id;

            await _appDbContext.RecipeComments.AddAsync(recipeComment);
            await _appDbContext.SaveChangesAsync();

            return new RecipeCommentDto
            {
                RecipeComment_Id = recipeComment.RecipeComment_Id,
                Recipe_Id = recipe_id,
                Member_Id = member_id,
                RecipeComment_Content = recipeComment.RecipeComment_Content,
                RecipeComment_Date = recipeComment.RecipeComment_Date
            };
        }

        public async Task<RecipeCommentDto> DeleteRecipeComment(Guid member_id, Guid recipe_id, Guid recipeComment_id)
        {
            if (!await _appDbContext.Recipes.AnyAsync(r => r.Recipe_Id == recipe_id))
                throw new InvalidOperationException("Recipe not found");
            if (!await _appDbContext.Members.AnyAsync(m => m.Member_Id == member_id))
                throw new InvalidOperationException("Member not found");

            var recipe = await _utils.GetRecipeIfOwner(recipe_id, member_id);

            var recipeComment = await _appDbContext.RecipeComments.FindAsync(recipeComment_id) ?? throw new InvalidOperationException("Recipe Comment not found");
            _appDbContext.Remove(recipeComment);
            await _appDbContext.SaveChangesAsync();

            return new RecipeCommentDto
            {
                RecipeComment_Id = recipeComment_id,
                Member_Id = member_id,
                Recipe_Id = recipe_id,
                RecipeComment_Content = recipeComment.RecipeComment_Content,
                RecipeComment_Date = recipeComment.RecipeComment_Date
            };
        }
    }
}