namespace NomNomNosh.Domain.Entities
{
    public class Comment
    {
        public Guid Comment_Id { get; set; }
        public Guid Recipe_Id { get; set; }
        public Guid Member_Id { get; set; }
        public string Comment_Content { get; set; }
        public DateTime Comment_Date { get; set; }
    }
}