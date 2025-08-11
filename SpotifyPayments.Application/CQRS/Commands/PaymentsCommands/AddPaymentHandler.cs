using AutoMapper;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Exceptions;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;
using SpotifyPayments.Application.CQRS.Commands.BalanceCommands;
using SpotifyPayments.Application.Services;

namespace SpotifyPayments.Application.CQRS.Commands.PaymentsCommands;

public class AddPaymentHandler(IPaymentRepository paymentRepository, IClientRepository clientRepository, IMapper mapper, IMediator mediator, IBalanceService balanceService) : IRequestHandler<AddPaymentCommand, PaymentDto>
{
    public async Task<PaymentDto> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var existingClient = await clientRepository.GetAsync(request.ClientId);

        if (existingClient is null)
            throw new ItemNotFoundException("Client does not exist");

        if (request.AmountPaid % 6 != 0 || request.AmountPaid < 6) // Price of one month of subscritpion is 6 therefore if the price is not divisible by 6 throw an exception
            throw new AmountPaidException("Inncorect amount paid");

        var newPayment = new PaymentModel
        {
            DateOfPayment = DateTime.UtcNow,
            AmountPaid = request.AmountPaid,
            ClientId = request.ClientId,
            Client = existingClient,
        };

        await paymentRepository.AddAsync(newPayment);

        await mediator.Send(new PutBalanceCommand
        {
            ClientId = request.ClientId,
            AmountPaid = request.AmountPaid
        });

        return mapper.Map<PaymentDto>(newPayment);
    }
}
