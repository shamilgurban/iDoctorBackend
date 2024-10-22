using iDoctor.Application.Dtos.EducationDtos;
using Microsoft.AspNetCore.Http;

namespace iDoctor.Application.Dtos.DoctorDtos
{
    public class UpdateDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public string City { get; set; }
        public string? District { get; set; }
        public string Country { get; set; }
        public int? ZipCode { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }
        public int SpecialtyId { get; set; }
        public List<CreateEducationDto> Educations { get; set; }
        public IFormFile Image { get; set; }


    }
}
