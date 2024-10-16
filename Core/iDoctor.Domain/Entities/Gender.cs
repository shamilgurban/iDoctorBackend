using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Gender:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Patient>Patients { get; set; }
    }
}
