using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Commands.ClientCommands;

public record AddClientCommand : IRequest<ClientDto>
{
    public string Name { get; set; }
}
