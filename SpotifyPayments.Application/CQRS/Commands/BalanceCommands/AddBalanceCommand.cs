using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Commands.BalanceCommands;

public record AddBalanceCommand : IRequest<BalanceDto>
{
    public int ClientId { get; set; }
}
