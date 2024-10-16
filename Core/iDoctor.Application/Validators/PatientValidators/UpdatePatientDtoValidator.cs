using FluentValidation;
using iDoctor.Application.Dtos.PatientDtos;


namespace iDoctor.Application.Validators.PatientValidators
{
    public class UpdatePatientDtoValidator : AbstractValidator<UpdatePatientDto>
    {
        public UpdatePatientDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Phone)
              .NotEmpty().WithMessage("Phone is required.")
              .Matches(@"^\+994(\s?)\d{2}(\s?)\d{3}(\s?)\d{2}(\s?)\d{2}$")
              .WithMessage("Please enter a valid Azerbaijan phone number.");
 
            RuleFor(x => x.BirthDate)
                .Must(date => date == null || date <= DateTime.UtcNow).WithMessage("BirthDate must be in the past or null.");

        }
    }
}
