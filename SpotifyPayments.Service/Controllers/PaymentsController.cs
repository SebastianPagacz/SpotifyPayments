using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayments.Application.CQRS.Commands.PaymentsCommands;
using SpotifyPayments.Application.CQRS.Queries.PaymentQueris;

namespace SpotifyPayments.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(int amountPaid, int clientId)
    {
        var result = await mediator.Send(new AddPaymentCommand
        {
            AmountPaid = amountPaid,
            ClientId = clientId,
        });

        return StatusCode(200, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) 
    {
        var result = await mediator.Send(new GetPaymentQuery { Id = id });

        return StatusCode(200, result);
    }
}
