using StudentManagementSystemFullStack.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
namespace StudentManagementSystemFullStack.Services.Implementations
{
    public class EmailService : IEmailService
    {   

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config["EmailConfiguration:From"]!));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _config["EmailConfiguration:SmtpServer"],
                int.Parse(_config["EmailConfiguration:Port"]!),
                SecureSocketOptions.StartTls
            );

            await smtp.AuthenticateAsync(
                _config["EmailConfiguration:Username"],
                _config["EmailConfiguration:Password"]
            );

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
