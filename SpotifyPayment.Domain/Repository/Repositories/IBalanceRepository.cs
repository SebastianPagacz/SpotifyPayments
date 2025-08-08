using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository.Repositories;

public interface IBalanceRepository
{
    public Task<BalanceModel> AddAsync(BalanceModel balance);
    public Task<BalanceModel> GetAsync(int id);
    public Task<List<BalanceModel>> GetAllAsync();
    public Task<BalanceModel> UpdateAsync(BalanceModel balance);
}
