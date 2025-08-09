using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Commands.BalanceCommands;

public record PutBalanceCommand : IRequest<BalanceDto>
{
    public int ClientId { get; set; }
    public int AmountPaid { get; set; }
}
