using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public bool IsVerified { get; set; }
        public string VerificationDocumentPath { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
