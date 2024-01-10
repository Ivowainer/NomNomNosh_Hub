namespace NomNomNosh.Domain.Entities
{
    public class RecipeStep
    {
        public Guid RecipeStep_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public string Title { get; set; }
        public string RecipeStep_Content { get; set; }

        // One recipe have many RecipeStep, One to many: (Recipe => RecipeSteps)
        public virtual Recipe Recipe { get; set; }
    }
}