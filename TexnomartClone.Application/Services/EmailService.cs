using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Application.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    private readonly IConfiguration _config = configuration.GetSection("Email");

    public async Task SendMessageToEmailAsync(string to, string title, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = title;
        email.Body = new TextPart(TextFormat.Plain) { Text = body };

        var smtp = new SmtpClient();
        await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_config["EmailAddress"], _config["Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
