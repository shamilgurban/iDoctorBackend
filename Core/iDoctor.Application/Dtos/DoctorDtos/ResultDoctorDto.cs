

using iDoctor.Application.Dtos.EducationDtos;

namespace iDoctor.Application.Dtos.DoctorDtos
{
    public class ResultDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsVerified { get; set; }  
        public string Biography { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress { get; set; }
        public string SpecialtyName { get; set; }
        public string VerificationDocumentPath { get; set; }
        public List<ResultEducationDto> Educations { get; set; }
        public string Image { get; set; }

    }
}
