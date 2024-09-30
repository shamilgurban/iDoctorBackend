using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
