using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Application.CQRS.Commands.PaymentsCommands;

public class AddPaymentHandler(IPaymentRepository paymentRepository, IClientRepository clientRepository) : IRequestHandler<AddPaymentCommand, PaymentDto>
{
    public async Task<PaymentDto> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var existingClient = await clientRepository.GetAsync(request.ClientId); // TODO: Add custom exception

        if (existingClient is null || existingClient.IsDeleted)
            throw new Exception("Client does not exist");

        // Calculating validity 
        var today = DateTime.UtcNow;
        var calculatedValidity = DateOnly.FromDateTime(today).AddMonths(request.AmountPaid / 6);

        var newPayment = new PaymentModel
        {
            DateOfPayment = today,
            ValididtyOfPayment = calculatedValidity,
            AmountPaid = request.AmountPaid,
            ClientId = request.ClientId,
            Client = existingClient,
        };

        await paymentRepository.AddAsync(newPayment);

        var resultDto = new PaymentDto
        {
            DateOfPayment = today,
            ValididtyOfPayment = calculatedValidity,
            AmountPaid = request.AmountPaid
        };
        return resultDto;
    }
}
