using System.Text.RegularExpressions;

namespace NomNomNosh.Infrastructure.Utils
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
