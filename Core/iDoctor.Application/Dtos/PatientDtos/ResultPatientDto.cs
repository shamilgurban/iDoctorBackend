
namespace iDoctor.Application.Dtos.PatientDtos
{
    public class ResultPatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string HealthRecord { get; set; }

        public string Image { get; set; }


    }
}
