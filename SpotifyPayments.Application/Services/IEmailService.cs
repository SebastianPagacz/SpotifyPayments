namespace SpotifyPayments.Application.Services;

public interface IEmailService
{
    /// <summary>
    /// Sends an email message to email address provided as a parameter.
    /// </summary>
    /// <param name="email">Recipient email address</param>
    /// <param name="message">Content of the message sent</param>
    /// <returns><see cref="Task"/>representing the asynchronous operation.</returns>
    Task SendEmailAsync(string email, string message);
}
