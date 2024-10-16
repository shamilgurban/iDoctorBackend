

using FluentValidation;
using iDoctor.Application.Dtos.BloodTypeDtos;

namespace iDoctor.Application.Validators.BloodTypeValidators
{
    public class CreateBloodTypeValidator:AbstractValidator<CreateBloodTypeDto>
    {
        public CreateBloodTypeValidator()
        {
            RuleFor(x => x.Type)
           .NotEmpty().WithMessage("Blood Type is required ")
           .Length(2, 50).WithMessage("Blood Type must be between 2 and 50 characters");
        }
    }
}
