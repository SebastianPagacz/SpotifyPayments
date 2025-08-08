using AutoMapper;
using MediatR;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Queries.ClientPaymentQueries;

public class GetClientPaymentsHandler(IClientRepository clientRepository, IPaymentRepository paymentRepository, IMapper mapper) : IRequestHandler<GetClientPaymentsQuery, List<PaymentDto>>
{
    public async Task<List<PaymentDto>> Handle(GetClientPaymentsQuery request, CancellationToken cancellationToken)
    {
        var exisitingClient = await clientRepository.GetAsync(request.ClientId);

        if (exisitingClient == null)
            throw new ItemNotFoundException("Client does not exist");

        var allPayments = await paymentRepository.GetAllAsync();

        var dataPerClient = allPayments.Where(p => p.ClientId == request.ClientId).ToList();

        return mapper.Map<List<PaymentDto>>(dataPerClient);
    }
}
