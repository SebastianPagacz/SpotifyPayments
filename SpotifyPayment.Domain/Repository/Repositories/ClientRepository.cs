using Microsoft.EntityFrameworkCore;
using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository.Repositories;

public class ClientRepository(DataContext context) : IClientRepository
{
    public async Task<ClientModel> AddAsync(ClientModel client)
    {
        await context.Clients.AddAsync(client);
        await context.SaveChangesAsync();
        
        return client;
    }

    public async Task<List<ClientModel>> GetAllAsync()
    {
        return await context.Clients.ToListAsync();
    }

    public async Task<ClientModel> GetAsync(int id)
    {
        return await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ClientModel> UpdateAsync(ClientModel client)
    {
        await context.SaveChangesAsync();

        return client;
    }
}
