using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Commands.BalanceCommands;

public class PutBalanceHandler(IBalanceRepository repository, IMapper mapper) : IRequestHandler<PutBalanceCommand, BalanceDto>
{
    public async Task<BalanceDto> Handle(PutBalanceCommand request, CancellationToken cancellationToken)
    {
        var exisitngBalance = await repository.GetBalanceForClientAsync(request.ClientId) ?? throw new ItemNotFoundException("Balance was not found"); // TODO: maybe instead of exception create new balance for the client

        var validPeriods = request.AmountPaid / 6;

        exisitngBalance.ValidUntil = exisitngBalance.ValidUntil.AddMonths(validPeriods);
        exisitngBalance.BalanceAmount += request.AmountPaid;

        await repository.UpdateAsync(exisitngBalance);

        return mapper.Map<BalanceDto>(exisitngBalance);
    }
}
