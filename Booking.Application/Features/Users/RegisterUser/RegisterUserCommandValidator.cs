using FluentValidation;

namespace Booking.Application.Features.Users.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.UserDto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 6 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
                .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.UserDto.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.UserDto.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(30);

            RuleFor(x => x.UserDto.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(30);

            RuleFor(x => x.UserDto.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20);
        }
    }
}