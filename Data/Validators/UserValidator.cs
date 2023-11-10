using Data.DTOs;
using FluentValidation;

namespace Data.Validators;

public sealed class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(x => x.Email).NotNull();
    }
}