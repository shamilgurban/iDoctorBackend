

namespace iDoctor.Application.Dtos.EducationDtos
{
    public class UpdateEducationDto
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string FieldOfStudy { get; set; }
        public int DoctorId { get; set; }
    }
}
