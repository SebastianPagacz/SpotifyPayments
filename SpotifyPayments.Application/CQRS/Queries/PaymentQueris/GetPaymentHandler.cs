using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Queries.PaymentQueris;

public class GetPaymentHandler(IPaymentRepository repository, IMapper mapper) : IRequestHandler<GetPaymentQuery, PaymentDto>
{
    public async Task<PaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var existingPayment = await repository.GetAsync(request.Id);

        if (existingPayment == null) // TODO: Add custom exception
            throw new ItemNotFoundException("Payment does not exist");

        return mapper.Map<PaymentDto>(existingPayment);
    }
}
