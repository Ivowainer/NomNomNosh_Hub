namespace NomNomNosh.Domain.Entities
{
    public class Member
    {
        public Guid Member_Id { get; set; }
        public string Username { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile_Image { get; set; }

        // Recipes created by Member, One to Many (Member => Recipes)
        public ICollection<Recipe> Recipes { get; set; }

        // RecipesComments created by Member, One to Many (Member => RecipeComments)
        public virtual ICollection<RecipeComment> RecipeComments { get; set; }

        // RecipeRate created by Member, One to Many (Member => RecipeRate)
        public virtual ICollection<RecipeRate> RecipeRates { get; set; }

        // RecipeSaved saved by Member, One to Many (Member => RecipeSaved)
        public virtual ICollection<RecipeSaved> RecipesSaved { get; set; }
    }
}