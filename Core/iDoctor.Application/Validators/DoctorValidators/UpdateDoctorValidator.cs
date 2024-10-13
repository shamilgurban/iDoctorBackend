using FluentValidation;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Validators.EducationValidators;


namespace iDoctor.Application.Validators.DoctorValidators
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctorDto>
    {
        public UpdateDoctorValidator()
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

            RuleFor(x => x.ZipCode)
                  .InclusiveBetween(1000, 9999)
                  .WithMessage("ZIP code must be a 4-digit number.");

            RuleFor(x => x.ClinicName)
                .NotEmpty().WithMessage("Clinic Name is required")
                .Length(3,100).WithMessage("Clinic Name must be between 3 and 100 characters");

            RuleFor(x => x.ClinicAddress)
               .NotEmpty().WithMessage("Clinic Address is required")
               .Length(3, 300).WithMessage("Clinic Name must be between 3 and 300 characters");

            RuleFor(x => x.SpecialtyId)
                .NotEmpty().WithMessage("SpecialyId is required");

            RuleForEach(d => d.Educations)
            .SetValidator(new CreateEducationValidator());



        }
    }
}
