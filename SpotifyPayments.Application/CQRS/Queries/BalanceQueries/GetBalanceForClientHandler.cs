using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Queries.BalanceQueries;

public class GetBalanceForClientHandler(IBalanceRepository balanceRepository, IClientRepository clientRepository, IMapper mapper) : IRequestHandler<GetBalanceForClientQuery, BalanceDto>
{
    public async Task<BalanceDto> Handle(GetBalanceForClientQuery request, CancellationToken cancellationToken)
    {
        var exisitngClient = await clientRepository.GetAsync(request.ClientId) ?? throw new ItemNotFoundException("Client not found");
        var exisitngBalance = await balanceRepository.GetBalanceForClientAsync(request.ClientId) ?? throw new ItemNotFoundException("Balance not found"); 

        return mapper.Map<BalanceDto>(exisitngBalance);
    }
}
