using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Commands.BalanceCommands;

public class AddBalanceHandler(IBalanceRepository balanceRepository, IClientRepository clientRepository, IMapper mapper) : IRequestHandler<AddBalanceCommand, BalanceDto>
{
    public async Task<BalanceDto> Handle(AddBalanceCommand request, CancellationToken cancellationToken)
    {
        var exisitngBalance = await balanceRepository.ClientBalanceAsync(request.ClientId);
        var exisitngClient = await clientRepository.GetAsync(request.ClientId) ?? throw new ItemNotFoundException("Client does not exist");
        
        if (exisitngBalance)
            throw new Exception("Balance already exist"); // TODO: create ItemAlreadyExistException throws 409

        var currentDate = DateTime.UtcNow;
        DateOnly currentDateOnly = new(currentDate.Year, currentDate.Month, 10);
        if (DateOnly.FromDateTime(DateTime.Now) > currentDateOnly)
            currentDateOnly = currentDateOnly.AddMonths(1);


        var newBalance = new BalanceModel
        {
            BalanceAmount = 0,
            ValidUntil = currentDateOnly,
            ClientId = request.ClientId,
            Client = exisitngClient,
        };
        
        await balanceRepository.AddAsync(newBalance);

        return mapper.Map<BalanceDto>(newBalance);
    }
}
