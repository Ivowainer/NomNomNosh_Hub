using System.Text.RegularExpressions;
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

        public string GenerateSlug(string phrase)
        {
            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}