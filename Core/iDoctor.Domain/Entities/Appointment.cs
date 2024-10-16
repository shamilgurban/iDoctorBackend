using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Appointment:BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AnalysisId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AnalysisDocumentPath { get; set; }
        public int Status { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Analysis Analysis { get; set; }
    }
}
