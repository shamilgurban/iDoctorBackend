using Microsoft.AspNetCore.Http;


namespace iDoctor.Application.Dtos.AppointmentDtos
{
    public class UpdateAppointmentDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AnalysisId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public IFormFile AnalysisDocument { get; set; }
     
    }
}
