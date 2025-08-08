using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Queries.BalanceQueries;

public record GetBalanceForClientQuery : IRequest<BalanceDto>
{
    public int ClientId { get; set; }
}
