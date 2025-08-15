namespace SpotifyPayments.Application.Services;

public interface IBalanceService
{
    /// <summary>
    /// Asynchronously processes user balances and sends email notifications to users with a negative balance.
    /// </summary>
    /// <param name="processedAmount">The amount that will be subtracted from the users balance at a time.</param>
    /// <returns><see cref="Task"/> representing asynchronous operation.</returns>
    Task ProcessMonthlyBalancesAsync(int processedAmount);
}
