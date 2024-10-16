using FluentValidation;
using iDoctor.Application.Dtos.SpecialtyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Validators.SpecialtyValidators
{
    public class UpdateSpecialtyValidator:AbstractValidator<UpdateSpecialtyDto>
    {
        public UpdateSpecialtyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Specialty Name is required")
                .Length(3, 50).WithMessage("Specialty Name must be between 3 and 50");
        }
    }
}
