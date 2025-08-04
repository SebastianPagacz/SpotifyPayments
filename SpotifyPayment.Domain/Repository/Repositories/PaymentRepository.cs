using Microsoft.EntityFrameworkCore;
using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository.Repositories;

public class PaymentRepository(DataContext context) : IPaymentRepository
{
    public async Task<PaymentModel> AddAsync(PaymentModel payment)
    {
        await context.Payments.AddAsync(payment);
        await context.SaveChangesAsync();

        return payment;
    }

    public async Task<List<PaymentModel>> GetAllAsync()
    {
        return await context.Payments.ToListAsync();
    }

    public async Task<PaymentModel> GetAsync(int id)
    {
        return await context.Payments.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<PaymentModel> UpdateAsync(PaymentModel payment)
    {
        await context.SaveChangesAsync();
        
        return payment;
    }
}
