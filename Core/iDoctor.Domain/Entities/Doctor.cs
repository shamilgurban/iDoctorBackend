using iDoctor.Domain.Entities.Common;


namespace iDoctor.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public bool IsVerified { get; set; }
        public string VerificationDocumentPath { get; set; }
        public string? Biography { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Country { get; set; }
        public int? ZipCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
