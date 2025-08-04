using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository.Repositories;

public interface IClientRepository
{
    public Task<ClientModel> AddAsync(ClientModel client);
    public Task<List<ClientModel>> GetAllAsync();
    public Task<ClientModel> GetAsync(int id);
    public Task<ClientModel> UpdateAsync(ClientModel client);
}
