using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Queries.ClientQueries;

public class GetAllClientHandler(IClientRepository repository, IMapper mapper) : IRequestHandler<GetAllClientsQuery, List<ClientDto>>
{
    public async Task<List<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var clientsList = await repository.GetAllAsync();

        return mapper.Map<List<ClientDto>>(clientsList);
    }
}
