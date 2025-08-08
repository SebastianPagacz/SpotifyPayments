namespace SpotifyPayment.Domain.Dtos;

public class BalanceDto
{
    public int BalanceAmount { get; set; }
    public DateOnly ValidUntil { get; set; }
}
