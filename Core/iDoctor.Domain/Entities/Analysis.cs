using iDoctor.Domain.Entities.Common;

namespace iDoctor.Domain.Entities
{
    public class Analysis:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
