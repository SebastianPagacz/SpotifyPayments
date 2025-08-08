namespace SpotifyPayment.Domain.Models;

public class BalanceModel
{
    public int Id { get; set; }
    public int BalanceAmount { get; set; }
    public DateOnly ValidUntil { get; set; }

    public int ClientId { get; set; }
    public ClientModel Client { get; set; }
}
