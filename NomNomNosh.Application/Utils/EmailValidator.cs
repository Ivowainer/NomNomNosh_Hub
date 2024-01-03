using System.Text.RegularExpressions;

using NomNomNosh.Application.Utils.Interface;

namespace NomNomNosh.Application.Utils
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
