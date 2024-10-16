using FluentValidation;
using iDoctor.Application.Dtos.DoctorDtos;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.X509;


namespace iDoctor.Application.Validators.DoctorValidators
{
    public class RegisterDoctorValidator : AbstractValidator<RegisterDoctorDto>
    {
        public RegisterDoctorValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required.")
             .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required.")
            .Length(2, 50).WithMessage("Surname must be between 2 and 50 characters.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.ConfirmPassword)
           .NotEmpty().WithMessage("Confirm Password is required.")
           .Equal(x => x.Password).WithMessage("Passwords do not match.");

            RuleFor(x => x.VerificationDocument)
                .Must(BeValidDocument)
                .When(x => x.VerificationDocument != null)
                .WithMessage("Document must be a valid PDF, TXT, DOC or DOCX and less than 10MB");
        }

        private bool BeValidDocument(IFormFile? file)
        {
            if (file == null) return false;

            const long maxDocSizeInBytes = 10 * 1024 * 1024;

            if(file.Length>maxDocSizeInBytes) return false;

            var allowedDocExtensions= new[] {".pdf",".txt",".doc",".docx"};

            var fileExtensions = Path.GetExtension(file.FileName).ToLowerInvariant();

            return allowedDocExtensions.Contains(fileExtensions);
        }
    }
}
