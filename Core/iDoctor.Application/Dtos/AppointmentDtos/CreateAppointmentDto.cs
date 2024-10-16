using Microsoft.AspNetCore.Http;

namespace iDoctor.Application.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AnalysisId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public IFormFile AnalysisDocument { get; set; }
    }
}
