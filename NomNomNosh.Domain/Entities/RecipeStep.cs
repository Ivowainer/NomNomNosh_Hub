namespace NomNomNosh.Domain.Entities
{
    public class RecipeStep
    {
        public Guid RecipeStep_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}