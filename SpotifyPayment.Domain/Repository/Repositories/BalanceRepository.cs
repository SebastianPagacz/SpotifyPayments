using Microsoft.EntityFrameworkCore;
using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository.Repositories;

public class BalanceRepository(DataContext context) : IBalanceRepository
{
    public async Task<BalanceModel> AddAsync(BalanceModel balance)
    {
        await context.Balances.AddAsync(balance);
        await context.SaveChangesAsync();
        return balance;
    }

    public async Task<List<BalanceModel>> GetAllAsync()
    {
        return await context.Balances.ToListAsync();
    }

    public async Task<BalanceModel> GetAsync(int id)
    {
        return await context.Balances.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<BalanceModel> UpdateAsync(BalanceModel balance)
    {
        await context.SaveChangesAsync();
        return balance;
    }

    public async Task<bool> ClientBalanceAsync(int clientId)
    {
        return await context.Balances.AnyAsync(b => b.ClientId == clientId);
    }

    public async Task<BalanceModel> GetBalanceForClientAsync(int clientId)
    {
        return await context.Balances.FirstOrDefaultAsync(b => b.ClientId == clientId);
    }
}
