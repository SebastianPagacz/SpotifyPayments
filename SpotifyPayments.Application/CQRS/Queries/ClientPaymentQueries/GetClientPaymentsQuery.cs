using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Queries.ClientPaymentQueries;

public record GetClientPaymentsQuery : IRequest<List<PaymentDto>>
{
    public int ClientId { get; set; }
}
