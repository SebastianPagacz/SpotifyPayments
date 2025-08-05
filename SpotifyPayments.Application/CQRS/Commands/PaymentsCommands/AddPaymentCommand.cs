using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Commands.PaymentsCommands;

public record AddPaymentCommand : IRequest<PaymentDto>
{
    public int ClientId { get; set; }
    public int AmountPaid { get; set; }
}
