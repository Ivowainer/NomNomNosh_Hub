namespace NomNomNosh.Domain.Entities
{
    public class RecipeImage
    {
        public Guid RecipeImage_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public string Url { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}