using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPayments.Application.CQRS.Queries.ClientPaymentQueries;

namespace SpotifyPayments.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientPaymentsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetPayemntsForClient(int clientId)
    {
        var result = await mediator.Send(new GetClientPaymentsQuery { ClientId = clientId });

        return StatusCode(200, result);
    }
}
