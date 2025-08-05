using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Queries.PaymentQueris;

public record GetPaymentQuery : IRequest<PaymentDto>
{
    public int Id { get; set; }
}
