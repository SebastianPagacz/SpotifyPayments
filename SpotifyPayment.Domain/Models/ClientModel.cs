namespace SpotifyPayment.Domain.Models;

public class ClientModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<PaymentModel> Payments { get; set; } = new();
    public BalanceModel? Balance { get; set; }
}
