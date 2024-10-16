using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Patient:BaseEntity
    {
        public DateTime? BirthDate { get; set; }
        public string? HealthRecord { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? BloodTypeId { get; set; }
        public virtual BloodType BloodType { get; set; }
        public int? MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
