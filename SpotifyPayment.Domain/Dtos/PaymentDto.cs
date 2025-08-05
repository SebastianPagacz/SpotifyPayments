namespace SpotifyPayment.Domain.Dtos;

public class PaymentDto
{
    public int AmountPaid { get; set; }
    public DateTime DateOfPayment { get; set; }
    public DateOnly ValididtyOfPayment { get; set; }
}
