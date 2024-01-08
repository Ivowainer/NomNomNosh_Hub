namespace NomNomNosh.Application.DTOs
{
    public class RecipeStepDto
    {
        public Guid RecipeStep_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}