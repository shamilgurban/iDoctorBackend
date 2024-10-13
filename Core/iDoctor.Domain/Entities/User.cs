using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Type { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
