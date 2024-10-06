

namespace iDoctor.Application.Dtos.DoctorDtos
{
    public class ResultDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public string Image { get; set; }
        public string VerificationDocumentPath { get; set; }

    }
}
