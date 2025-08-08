using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Queries.ClientQueries;

public class GetClientHandler(IClientRepository repository, IMapper mapper) : IRequestHandler<GetClientQuery, ClientDto>
{
    public async Task<ClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var existingClient = await repository.GetAsync(request.Id);

        if (existingClient == null)
            throw new ItemNotFoundException("Client was not found");

        return mapper.Map<ClientDto>(existingClient);
    }
}
