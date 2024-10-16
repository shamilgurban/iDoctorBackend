

namespace iDoctor.Application.Dtos.AppointmentDtos
{
    public class ResultAppointmentDto
    {
        public int Id { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public string AnalysisName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AnalysisDocumentPath { get; set; }
        public string Status { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
