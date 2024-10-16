
using FluentValidation;
using iDoctor.Application.Dtos.AppointmentDtos;

namespace iDoctor.Application.Validators.AppointmentValidators
{
    public class AcceptAppointmentValidator:AbstractValidator<AcceptAppointmentDto>
    {
        public AcceptAppointmentValidator()
        {
            RuleFor(x => x.DoctorReview).NotEmpty().WithMessage("Doctor Review is required")
                                      .MinimumLength(100).WithMessage("Doctor Review at least must have 100 characters");
        }
    }
}
