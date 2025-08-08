using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;
using SpotifyPayments.Application.CQRS.Commands.BalanceCommands;

namespace SpotifyPayments.Application.CQRS.Commands.ClientCommands;

public class AddClientHandler(IClientRepository repository, IMapper mapper, IMediator mediator) : IRequestHandler<AddClientCommand, ClientDto>
{
    public async Task<ClientDto> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var newClient = new ClientModel
        {
            Name = request.Name
        };

        await repository.AddAsync(newClient);

        await mediator.Send(new AddBalanceCommand { ClientId = newClient.Id });

        return mapper.Map<ClientDto>(newClient);
    }
}
