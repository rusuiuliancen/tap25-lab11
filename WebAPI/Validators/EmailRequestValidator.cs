using FluentValidation;
using WebAPI.Models;

namespace WebAPI.Validators
{
    public class EmailRequestValidator : AbstractValidator<EmailRequest>
    {
        public EmailRequestValidator()
        {
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("Recipient email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Body is required.");
        }
    }
}
