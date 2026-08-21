using ECommerce.Core.DTO.Identity;
using ECommerce.Core.Services;
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
            MimeMessage message = new();

            message.From.Add(new MailboxAddress("E-Commerece", _configuration["EmailSettings:From"]!));
            message.Subject = dto.Subject;
            message.To.Add(new MailboxAddress(dto.To, dto.To));
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Content
            };

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(
                        _configuration["EmailSettings:Smpt"],
                        int.Parse(_configuration["EmailSettings:Port"]
                        ?? throw new InvalidOperationException("EmailSettings:Port is missing")),
                        true);

                    await smtp.AuthenticateAsync(_configuration["EmailSettings:UserName"],
                        _configuration["EmailSettings:Password"]);

                    await smtp.SendAsync(message);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    smtp.Disconnect(true);
                    smtp.Dispose();
                }
            }
        }
    }
}
