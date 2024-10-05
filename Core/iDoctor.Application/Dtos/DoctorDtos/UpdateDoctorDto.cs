

using Microsoft.AspNetCore.Http;

namespace iDoctor.Application.Dtos.DoctorDtos
{
    public class UpdateDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public IFormFile? Image { get; set; }


    }
}
