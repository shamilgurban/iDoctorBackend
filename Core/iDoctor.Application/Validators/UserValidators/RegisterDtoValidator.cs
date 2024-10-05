using FluentValidation;
using iDoctor.Application.Dtos.UserDtos;


namespace iDoctor.Application.Validators.UserValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required.")
             .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required.")
            .Length(2, 50).WithMessage("Surname must be between 2 and 50 characters.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.ConfirmPassword)
           .NotEmpty().WithMessage("Confirm Password is required.")
           .Equal(x => x.Password).WithMessage("Passwords do not match.");
        }
    }
}
