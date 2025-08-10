namespace SpotifyPayments.Application.Services;

public interface IBalanceService
{
    Task ProcessMonthlyBalancesAsync();
}
