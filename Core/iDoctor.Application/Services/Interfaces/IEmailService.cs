

using iDoctor.Application.Dtos.DoctorDtos;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto emailDto);
    }
}
