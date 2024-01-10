namespace NomNomNosh.Domain.Entities
{
    public class RecipeComment
    {
        public Guid RecipeComment_Id { get; set; }
        public Guid? Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }
        public string RecipeComment_Content { get; set; }
        public DateTime RecipeComment_Date { get; set; }

        // Member, Recipe: One to Many, (Member => Comment), (Recipe => Comment)
        public Member Member { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}