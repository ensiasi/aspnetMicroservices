// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSetings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(EmailSettings emailSetings, ILogger<EmailService> logger)
        {
            _emailSetings = emailSetings;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            var apikey = _emailSetings.ApiKey;
            var client = new SendGridClient(apikey);
            var from = new EmailAddress(_emailSetings.FromAddress,_emailSetings.FromName);
            var subject = email.Subject;
            var to = new EmailAddress(email.To, email.To);
            var body = email.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body,body);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation("Email sent.");

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            _logger.LogError("Email sending failed.");
            return false;
        }
    }
}
