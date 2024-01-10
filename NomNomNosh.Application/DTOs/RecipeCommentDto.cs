namespace NomNomNosh.Application.DTOs
{
    public class RecipeCommentDto
    {
        public Guid RecipeComment_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }
        public string RecipeComment_Content { get; set; }
        public DateTime RecipeComment_Date { get; set; }
    }
}