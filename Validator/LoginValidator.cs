using FluentValidation;
using System.Text.RegularExpressions;
using UCDPNextGenPOCs.Enum;
using UCDPNextGenPOCs.Model;

namespace UCDPNextGenPOCs.Validator
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x)
            .Must(x => !string.IsNullOrWhiteSpace(x.Username) && !string.IsNullOrWhiteSpace(x.Password))
            .WithMessage("Please enter valid Username and Password.");

            RuleFor(x => x.Username)
            .EmailAddress()
            .Must(mail => !string.IsNullOrWhiteSpace(mail)).WithMessage("Username shou  ld be email address.");

            RuleFor(x => x)
            .Must(x => x.Username == "rashmin@gmail.com" && x.Password == "viramgama")
            .WithMessage("Authentication failed. You have entered an invalid Username or Password.")
            .WithErrorCode(ErrorCodes.Authentication.ToString());
        }
    }
}
