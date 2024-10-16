using FluentValidation;
using iDoctor.Application.Dtos.EducationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Validators.EducationValidators
{
    public class CreateEducationValidator:AbstractValidator<CreateEducationDto>
    {
        public CreateEducationValidator()
        {
            RuleFor(x => x.UniversityName)
                 .NotEmpty().WithMessage("University Name is required")
                 .Length(3, 100).WithMessage("University Name must be between 3 and 100 characters ");

            RuleFor(x => x.FieldOfStudy)
                .NotEmpty().WithMessage("Field of Study is required")
                .Length(3, 100).WithMessage("Field of Study must be between 3 and 100 characters ");

            RuleFor(x => x.DoctorId)
                .NotEmpty().WithMessage("Doctor Id is required");
        }
    }
}
