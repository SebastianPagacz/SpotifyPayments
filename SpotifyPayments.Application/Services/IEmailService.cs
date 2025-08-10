namespace SpotifyPayments.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(string email, string userName, string message);
}
