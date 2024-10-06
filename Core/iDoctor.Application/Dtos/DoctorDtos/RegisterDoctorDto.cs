
using Microsoft.AspNetCore.Http;

namespace iDoctor.Application.Dtos.DoctorDtos
{
    public class RegisterDoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile VerificationDocument { get; set; }
    }
}
