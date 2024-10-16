using iDoctor.Application.Dtos.EmailDtos;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto emailDto);
    }
}
