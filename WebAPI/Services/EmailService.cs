using System.Net;
using System.Net.Mail;
using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class EmailService : IEmailService
    {
        private const string SmtpHost = "smtp.example.com";
        private const int SmtpPort = 587;
        private const string SmtpUser = "your_smtp_user";
        private const string SmtpPass = "your_smtp_password";
        private const string FromEmail = "noreply@example.com";

        public async Task SendEmailAsync(EmailRequest request)
        {
            using var client = new SmtpClient(SmtpHost, SmtpPort)
            {
                Credentials = new NetworkCredential(SmtpUser, SmtpPass),
                EnableSsl = true
            };

            var mail = new MailMessage(FromEmail, request.To, request.Subject, request.Body);
            await client.SendMailAsync(mail);
        }
    }
}
