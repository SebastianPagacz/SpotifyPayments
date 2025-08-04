
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository;

namespace SpotifyPayment.Domain.Seeders;

public class ClientSeeder(DataContext context) : IClientSeeder
{
    public async Task SeedAsync()
    {
        if (!context.Clients.Any())
        {
            var clients = new List<ClientModel>
            {
                new ClientModel { Name = "Client1" },
                new ClientModel { Name = "Client2" },
                new ClientModel { Name = "Client3" },
                new ClientModel { Name = "Client4" },
                new ClientModel { Name = "Client5" }
            };

            await context.Clients.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }
    }
}
