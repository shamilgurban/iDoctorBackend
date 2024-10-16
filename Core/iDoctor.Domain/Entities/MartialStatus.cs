using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class MaritalStatus:BaseEntity
    {
        public string Status { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

    }
}
