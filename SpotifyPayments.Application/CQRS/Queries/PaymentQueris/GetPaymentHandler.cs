using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Queries.PaymentQueris;

public class GetPaymentHandler(IPaymentRepository repository) : IRequestHandler<GetPaymentQuery, PaymentDto>
{
    public async Task<PaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var existingPayment = await repository.GetAsync(request.Id);

        if (existingPayment == null) // TODO: Add custom exception
            throw new Exception("Payment does not exist");

        var resultDto = new PaymentDto
        {
            AmountPaid = existingPayment.AmountPaid,
            DateOfPayment = existingPayment.DateOfPayment,
            ValididtyOfPayment = existingPayment.ValididtyOfPayment,
        };

        return resultDto;
    }
}
