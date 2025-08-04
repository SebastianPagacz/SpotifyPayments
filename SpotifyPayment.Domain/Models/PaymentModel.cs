namespace SpotifyPayment.Domain.Models;

public class PaymentModel
{
    public int Id { get; set; }
    public DateTime DateOfPayment { get; set; }
    public DateTime ValididtyOfPayment { get; set; }
    public int AmountPaid { get; set; }

    public int ClientId { get; set; }
    public ClientModel Client { get; set; }
}
