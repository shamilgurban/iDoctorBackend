using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public bool IsVerified { get; set; }
        public string VerificationDocumentPath { get; set; }
        public string? Biography { get; set; }
        public string City { get; set; } = "Bakı";
        public string? District { get; set; }
        public string Country { get; set; } = "Azərbaycan";
        public int? ZipCode { get; set; }
        public string? ClinicName { get; set; }
        public string? ClinicAddress { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Appointment>Appointments { get; set; }
    }
}
