namespace NomNomNosh.Application.Request.Member
{
    public class MemberRegistrationRequest
    {
        public string Username { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile_Image { get; set; }
    }
}