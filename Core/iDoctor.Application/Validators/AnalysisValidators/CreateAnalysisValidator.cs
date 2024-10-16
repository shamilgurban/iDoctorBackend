using FluentValidation;
using iDoctor.Application.Dtos.AnalysisDtos;


namespace iDoctor.Application.Validators.AnalysisValidators
{
    public class CreateAnalysisValidator:AbstractValidator<CreateAnalysisDto>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Analysis Name is required")
                 .Length(3, 60).WithMessage("Analysis Name must be between 3 and 60 characters");
        }
    }
}
