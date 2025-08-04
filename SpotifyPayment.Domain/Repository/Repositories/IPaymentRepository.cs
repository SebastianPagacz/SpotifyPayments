using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Repository.Repositories;

public interface IPaymentRepository
{
    public Task<PaymentModel> AddAsync(PaymentModel payment);
    public Task<List<PaymentModel>> GetAllAsync();
    public Task<PaymentModel> GetAsync(int id);
    public Task<PaymentModel> UpdateAsync(PaymentModel payment);
}
