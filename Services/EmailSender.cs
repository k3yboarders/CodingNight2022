using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using Microsoft.EntityFrameworkCore;

namespace MailTest.Services
{
    public class EmailSender : IEmailSender
    {
        const string EmailFrom = "admin@mgala.ml";
        private string EmailPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("EmailPassword");

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse(EmailFrom));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.Connect("mail1.titanaxe.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                emailClient.Authenticate(EmailFrom, EmailPassword);
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }
    }
}
