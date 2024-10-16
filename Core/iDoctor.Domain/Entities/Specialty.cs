using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class Specialty:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
