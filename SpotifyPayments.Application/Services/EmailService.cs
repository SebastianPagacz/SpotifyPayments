
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace SpotifyPayments.Application.Services;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string email, string messageContent)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse("s.pagacz123@gmail.com"));
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = "Zalegasz z płatnością za Spotify!";
        message.Body = new TextPart("plain")
        {
            Text = messageContent
        };

        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync("placeholder", "placeholder");
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
