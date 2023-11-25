using Data.DTOs;
using Extensions;
using FluentValidation;

namespace Data.Validators;

public sealed class UserUpdateValidator : AbstractValidator<UserDTO>
{
    public UserUpdateValidator()
    {
        RuleFor(user => user.Email)
            .NotNull()
            .NotEmpty()
            .Must(email => email.IsValidEmail())
            .WithMessage("Email is invalid")
            .When(user => string.IsNullOrEmpty(user.Email) == false);
    }
}