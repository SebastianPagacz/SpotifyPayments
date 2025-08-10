namespace SpotifyPayment.Domain.Dtos.Requests;

public class AddPaymentRequest
{
    public int ClientId { get; set; }
    public int AmountPaid { get; set; }
}
