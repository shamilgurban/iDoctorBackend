using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class BloodType:BaseEntity
    {
        public string Type { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

    }
}
