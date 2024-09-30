
namespace iDoctor.Application.Dtos.Token
{
    public class TokenCreateDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
