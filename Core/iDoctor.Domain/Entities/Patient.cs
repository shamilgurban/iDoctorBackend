using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Patient:BaseEntity
    {
        public DateTime? BirthDate { get; set; }
        public string? HealthRecord { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? BloodTypeId { get; set; }
        public BloodType BloodType { get; set; }
        public int? MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
