using FluentValidation;
using iDoctor.Application.Dtos.BloodTypeDtos;

namespace iDoctor.Application.Validators.BloodTypeValidators
{
    public class UpdateBloodTypeValidator:AbstractValidator<UpdateBloodTypeDto>
    {
        public UpdateBloodTypeValidator()
        {
            RuleFor(x => x.Type)
           .NotEmpty().WithMessage("Blood Type is required ")
           .Length(2, 50).WithMessage("Blood Type must be between 2 and 50 characters");
        }
    }
}
