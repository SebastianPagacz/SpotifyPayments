using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;
using SpotifyPayments.Application.CQRS.Commands.ClientCommands;
using SpotifyPayments.Application.CQRS.Queries.ClientQueries;

namespace SpotifyPayments.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientDto client)
    {
        var result = await mediator.Send(new AddClientCommand { Name = client.Name });

        return StatusCode(200, result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllClientsQuery());

        return StatusCode(200, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetClientQuery { Id = id });

        return StatusCode(200, result);
    }
}
