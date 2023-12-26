namespace NomNomNosh.Domain.Entities
{
    public class RecipeRate
    {
        public Guid RecipeRate_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }
        public decimal Rating_Value { get; set; }

        // One to Many: (Member => RecipeRates), (Recipe => RecipeRates)
        public Member Member { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}