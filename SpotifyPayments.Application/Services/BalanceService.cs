using MediatR;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.Services;

public class BalanceService(IBalanceRepository repository, IEmailService emailService) : IBalanceService
{
    public async Task ProcessMonthlyBalancesAsync()
    {
        var allBalances = await repository.GetAllAsync();


        foreach (var balance in allBalances)
        {
            balance.BalanceAmount -= 6;

            if (balance.BalanceAmount < 0)
            {
                //await emailService.SendEmailAsync(balance.Client.Name, balance.Client.Name, $"Hej {balance.Client.Name} zalegasz z płatnością o Spotify o {balance.BalanceAmount / -6} miesięcy. Przemyśl swoje zachowanie i napraw swój błąd. Kreślę się z rewerencją :)");
            }
        }

        await repository.SaveChangesAsync();
    }
}
