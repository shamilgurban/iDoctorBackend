

using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Education:BaseEntity
    {
        public string UniversityName { get; set; }
        public string FieldOfStudy { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
