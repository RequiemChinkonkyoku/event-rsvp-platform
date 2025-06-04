using FluentValidation;
using Models.DTOs.Request;

namespace EventRsvpPlatform.Validators.Account;

public class UpdateAccountRequestValidator : AbstractValidator<UpdateAccountRequest>
{
    public UpdateAccountRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Full name can't exceed 100 characters.");

        // RuleFor(x => x.AvatarUrl)
        //     .Must(url => string.IsNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
        //     .WithMessage("AvatarUrl must be a valid URL.");
    }
}