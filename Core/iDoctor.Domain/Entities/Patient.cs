using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Patient:BaseEntity
    {
        public DateTime? BirthDate { get; set; }
        public string? HealthRecord { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
