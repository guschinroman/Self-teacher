using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Domain.Entities.EmailService;

namespace ServiceTeacher.Service.Infrastructure.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IOptions<EmailSettings> emailSettings,
            ILogger<EmailService> logger
            )
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            _logger.LogTrace("Start sending mail");
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));
                mimeMessage.To.Add(new MailboxAddress(email));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };
                _logger.LogTrace($"Create mail with sender: {_emailSettings.SenderName}, email reciver: {email} and message: {message}");

                using (var client = new SmtpClient())
                {
                    _logger.LogTrace("Smpt client created");

                    await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true);
                    _logger.LogTrace($"Smpt client connected to server - {_emailSettings.MailServer} and port - {_emailSettings.MailPort}");

                    await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);
                    _logger.LogTrace($"Smpt client authenticated with login - {_emailSettings.Sender}");

                    await client.SendAsync(mimeMessage);
                    _logger.LogTrace($"Message sended");

                    await client.DisconnectAsync(true);
                }

                _logger.LogTrace("End sending mail");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in sending email process", ex);
                throw new InvalidOperationException(ex.Message);
            }
            _logger.LogTrace("End send mail");
        }
    }
}
