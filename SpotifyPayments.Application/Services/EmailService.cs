
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Org.BouncyCastle.Security;

namespace SpotifyPayments.Application.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    public async Task SendEmailAsync(string email, string userName, string messageContent)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Płatności Spotify", "s.pagacz123@gmail.com"));
        message.To.Add(new MailboxAddress(userName, email));
        message.Subject = "Zalegasz z płatnością za Spotify!";
        message.Body = new TextPart("plain")
        {
            Text = messageContent
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(_configuration.GetSection("MailSettings")["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration.GetSection("MailSettings")["Name"], _configuration.GetSection("MailSettings")["Password"]);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
