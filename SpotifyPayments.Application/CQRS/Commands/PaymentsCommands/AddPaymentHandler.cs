using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Commands.PaymentsCommands;

public class AddPaymentHandler(IPaymentRepository paymentRepository, IClientRepository clientRepository, IMapper mapper) : IRequestHandler<AddPaymentCommand, PaymentDto>
{
    public async Task<PaymentDto> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var existingClient = await clientRepository.GetAsync(request.ClientId);

        if (existingClient is null)
            throw new ItemNotFoundException("Client does not exist");

        // Calculating validity 
        var today = DateTime.UtcNow;
        if (request.AmountPaid % 6 != 0 || request.AmountPaid < 6) // Price of one month of subscritpion is 6 therefore if the price is not divisible by 6 throw an exception
            throw new AmountPaidException("Inncorect amount paid");

        var newPayment = new PaymentModel
        {
            DateOfPayment = today,
            AmountPaid = request.AmountPaid,
            ClientId = request.ClientId,
            Client = existingClient,
        };

        await paymentRepository.AddAsync(newPayment);

        return mapper.Map<PaymentDto>(newPayment);
    }
}
