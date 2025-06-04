using FluentValidation;
using Models.DTOs.Request;

namespace EventRsvpPlatform.Validators.Account;

public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .Matches(@"\d")
            .WithMessage("Password must contain at least 1 number");

        RuleFor(x => x.Username)
            .NotEmpty();

        RuleFor(x => x.FullName)
            .NotEmpty();
    }
}