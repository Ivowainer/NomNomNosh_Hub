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

        // RecipeRate created by Member, One to Many (Member => RecipeRate)
        public virtual ICollection<RecipeRate> RecipeRates { get; set; }
    }
}