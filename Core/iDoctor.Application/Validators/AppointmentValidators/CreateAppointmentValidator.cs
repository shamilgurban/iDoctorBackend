using FluentValidation;
using iDoctor.Application.Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Http;

namespace iDoctor.Application.Validators.AppointmentValidators
{
    public class CreateAppointmentValidator:AbstractValidator<CreateAppointmentDto>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty().WithMessage("Pataient ID is required");
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Doctor ID is required");
            RuleFor(x => x.AnalysisId).NotEmpty().WithMessage("Analysis ID is required");

            RuleFor(x => x.AppointmentDate).NotEmpty()
                                           .WithMessage("Appointment Date is required")
                                           .GreaterThan(DateTime.Now)
                                           .WithMessage("Appointment Date must be in the future.");


            RuleFor(x => x.AnalysisDocument)
                .NotNull().WithMessage("Analysis Document is required. ")
                .Must(BeValidDocument)
                .When(x => x.AnalysisDocument != null)
                .WithMessage("Document must be a valid PDF, TXT, DOC or DOCX and less than 10MB");

           
        }

        private bool BeValidDocument(IFormFile? file)
        {
            if (file == null) return false;

            const long maxDocSizeInBytes = 10 * 1024 * 1024;

            if (file.Length > maxDocSizeInBytes) return false;

            var allowedDocExtensions = new[] { ".pdf", ".txt", ".doc", ".docx" };

            var fileExtensions = Path.GetExtension(file.FileName).ToLowerInvariant();

            return allowedDocExtensions.Contains(fileExtensions);
        }
    }
}
