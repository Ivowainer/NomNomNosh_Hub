namespace NomNomNosh.Domain.Entities
{
    public class RecipeComment
    {
        public Guid RecipeComment_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }
        public string RecipeComment_Content { get; set; }
        public DateTime RecipeComment_Date { get; set; }
    }
}