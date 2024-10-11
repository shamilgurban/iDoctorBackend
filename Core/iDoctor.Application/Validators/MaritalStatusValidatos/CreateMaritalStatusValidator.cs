using FluentValidation;
using iDoctor.Application.Dtos.MaritalStatusDtos;


namespace iDoctor.Application.Validators.MaritalStatusValidatos
{
    public class CreateMaritalStatusValidator:AbstractValidator<CreateMaritalStatusDto>
    {
        public CreateMaritalStatusValidator()
        {
            RuleFor(x => x.Status)
           .NotEmpty().WithMessage("Marital Status is required ")
           .Length(2, 50).WithMessage("Marital Status must be between 2 and 50 characters");
        }
    }
}
