using ECommerce.Core.DTO.Identity;
using ECommerce.Core.Services;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositories.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(EmailDTO dto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("App", GetRequiredConfig("EmailSettings:From")));
            message.Subject = dto.Subject;
            message.To.Add(new MailboxAddress(dto.To, dto.To));
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = dto.Content };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Timeout = 10000;

            try
            {
                await smtp.ConnectAsync(
                    GetRequiredConfig("EmailSettings:Smpt"),
                    int.Parse(GetRequiredConfig("EmailSettings:Port")),
                    SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(
                    GetRequiredConfig("EmailSettings:UserName"),
                    GetRequiredConfig("EmailSettings:Password"));

                await smtp.SendAsync(message);
            }
            finally
            {
                smtp.Disconnect(true);
            }
        }

        private string GetRequiredConfig(string key)
            => _configuration[key] ?? throw new InvalidOperationException($"{key} is missing from configuration");
    }
}
