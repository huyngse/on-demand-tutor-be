using System;
using BE_SWP391_OnDemandTutor.BusinessLogic.Helper.EmailSettings;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string to, string subject);
    }
    public class EmailSenderService : IEmailServices
    {
        private readonly EmailSettings _emailSettings;
        public EmailSenderService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        public async Task SendEmailAsync(string to, string subject)
        {
            var Email = new MimeMessage();
            Email.Sender = MailboxAddress.Parse(_emailSettings.Email);
            Email.To.Add(MailboxAddress.Parse(to));
            Email.Subject = subject;

            var builder = new BodyBuilder();

            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmailTemplates", "register.html");
            //var content = File.ReadAllText(path);

            //content = content.Replace("{{Email}}", to);

            //builder.HtmlBody = content;

            //Email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.Email, _emailSettings.Password);
            await smtp.SendAsync(Email);
            smtp.Disconnect(true);

        }
    }
}

