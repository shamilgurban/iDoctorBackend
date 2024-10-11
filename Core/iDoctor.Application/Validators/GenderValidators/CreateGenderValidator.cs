using FluentValidation;
using iDoctor.Application.Dtos.GenderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Validators.GenderValidators
{
    public class CreateGenderValidator:AbstractValidator<CreateGenderDto>
    {
        public CreateGenderValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Gender Name is required ")
           .Length(2, 50).WithMessage("Gender Name must be between 2 and 50 characters");
        }
    }
}
