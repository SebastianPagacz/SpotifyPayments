using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPayments.Application.CQRS.Queries.BalanceQueries;

namespace SpotifyPayments.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BalancesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{clientId}")]
    public async Task<IActionResult> Get(int clientId)
    {
        var result = await mediator.Send(new GetBalanceForClientQuery { ClientId = clientId });

        return StatusCode(200, result);
    }
}
