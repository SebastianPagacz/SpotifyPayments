using SpotifyPayment.Domain.Enums;

namespace SpotifyPayment.Domain.Dtos;

public class PaymentDto
{
    public DateTime DateOfPayment { get; set; }
    public int AmountPaid { get; set; }
    public PaymentStatusEnum PaymentStatus { get; set; }
}
