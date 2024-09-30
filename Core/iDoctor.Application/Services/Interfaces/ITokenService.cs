using iDoctor.Application.Dtos.Token;


namespace iDoctor.Application.Services.Interfaces
{
    public interface ITokenService
    {
        TokenDto GenerateJwtToken(TokenCreateDto request);
    }
}
