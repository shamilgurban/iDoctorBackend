using FluentValidation;
using iDoctor.Application.Dtos.GenderDtos;


namespace iDoctor.Application.Validators.GenderValidators
{
    public class UpdateGenderValidator:AbstractValidator<UpdateGenderDto>
    {
        public UpdateGenderValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Gender Name is required ")
                .Length(2, 50).WithMessage("Gender Name must be between 2 and 50 characters");
        }
    }
}
