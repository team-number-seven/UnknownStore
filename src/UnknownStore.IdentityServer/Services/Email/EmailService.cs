using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using UnknownStore.IdentityServer.Common.Options;
using UnknownStore.IdentityServer.Services.Google;

namespace UnknownStore.IdentityServer.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions _emailConfig;
        private readonly IGoogleService _google;
        private readonly ILogger<EmailService> _logger;


        public EmailService(IOptions<EmailServiceOptions> emailOptions, IGoogleService google,
            ILogger<EmailService> logger)
        {
            _google = google;
            _logger = logger;
            _emailConfig = emailOptions.Value;
        }

        public async Task SendEmailAsync(string email, string name, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(_emailConfig.FromName, _emailConfig.FromAddress));
                emailMessage.To.Add(new MailboxAddress(name, email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };
                var oauth2 = await _google.AuthorizationAsync();
                using var client = new SmtpClient();
                await client.ConnectAsync(_emailConfig.MailServerAddress, _emailConfig.MailServerPort,
                    _emailConfig.SecureSocket);
                await client.AuthenticateAsync(oauth2);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}