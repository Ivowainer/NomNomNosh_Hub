namespace NomNomNosh.Domain.Entities
{
    public class Member
    {
        public Guid Member_Id { get; set; }
        public string Username { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile_Image { get; set; }
    }
}