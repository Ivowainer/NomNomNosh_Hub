namespace NomNomNosh.Domain.Entities
{
    public class RecipeSaved
    {
        public Guid RecipeSaved_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }

        // Member, Recipe: One to Many, (Member => RecipeSaved), (Recipe => RecipeSaved)
        public Member Member { get; set; }
        public Recipe Recipe { get; set; }
    }
}