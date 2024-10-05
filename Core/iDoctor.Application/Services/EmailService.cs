using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;


namespace iDoctor.Application.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailDto emailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("IDoctor", "idoktormail@yandex.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("Receiver", emailDto.ReceiversMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailDto.Message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = emailDto.Subject;

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.com", 587, false);
            await client.AuthenticateAsync("idoktormail@yandex.com", "eqjmahvzvigwuhwn");
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);

      
        }
    }
}
