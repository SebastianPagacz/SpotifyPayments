using Microsoft.EntityFrameworkCore;
using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<PaymentModel> Payments { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<BalanceModel> Balances { get; set; }
}
