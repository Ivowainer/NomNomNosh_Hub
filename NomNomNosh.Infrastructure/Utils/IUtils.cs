using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Infrastructure.Utils
{
    public interface IUtils
    {
        Task<Recipe> GetRecipeIfOwner(Guid recipe_id, Guid member_id);
        string GenerateSlug(string phrase);
        string RemoveAccent(string txt);
    }
}