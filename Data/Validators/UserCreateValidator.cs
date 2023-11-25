using Data.DTOs;
using Extensions;
using FluentValidation;

namespace Data.Validators;

public sealed class UserCreateValidator : AbstractValidator<UserDTO>
{
    public UserCreateValidator()
    {
        RuleFor(user => user.Email)
            .NotNull()
            .NotEmpty()
            .Must(email => email.IsValidEmail())
            .WithMessage("Email is invalid");

        RuleFor(user => user.FirstName)
            .NotNull()
            .NotEmpty();

        RuleFor(user => user.LastName)
            .NotNull()
            .NotEmpty();

        RuleFor(user => user.Password)
            .NotNull()
            .NotEmpty()
            .Must(password => password.HasLength())
            .WithMessage("Password length must be in from 8 to 32 chars")

            .Must(password => password.HasUppercaseLetters())
            .WithMessage("Password must contain uppercase letters")

            .Must(password => password.HasLowercaseLetters())
            .WithMessage("Password must contain lowercase letters")

            .Must(password => password.HasSpecialChars())
            .WithMessage("Password must contain special chars")

            .Must(password => password.HasNumbers())
            .WithMessage("Password must contain numbers");
    }
}