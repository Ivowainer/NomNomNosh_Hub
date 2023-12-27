namespace NomNomNosh.Domain.Entities
{
    public class Recipe
    {
        public Guid Recipe_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Published_Date { get; set; }
        public string Main_Image { get; set; }
        public decimal Average_Rating { get; set; }

        // One to Many (Member => Recipes)
        public Member Member { get; set; }
        public Guid Member_Id { get; set; }

        // One recipe have many comments, One to Many (Recipe => Comments)
        public virtual ICollection<RecipeComment> RecipeComments { get; set; }

        // One recipe have many RecipeRates, One to Many (Recipe => RecipeRates)
        public virtual ICollection<RecipeRate> RecipeRates { get; set; }

        // One recipe have many RecipeImages, One to Many(Recipe => RecipeImages)
        public virtual ICollection<RecipeImage> RecipeImages { get; set; }

        // One recipe have many RecipeStep, One to many: (Recipe => RecipeSteps)
        public virtual ICollection<RecipeStep> RecipeSteps { get; set; }

        // One recipe have many RecipeSaved by Member, One to many: (Recipe => RecipeSaved)
        public virtual ICollection<RecipeSaved> RecipesSaved { get; set; }
    }
}