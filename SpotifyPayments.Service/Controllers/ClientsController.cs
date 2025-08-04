using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyPayment.Domain.Models;
using SpotifyPayment.Domain.Repository.Repositories;

namespace SpotifyPayments.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(IClientRepository repository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string name)
    {
        var newClient = new ClientModel { Name = name };
        await repository.AddAsync(newClient);

        return StatusCode(200, newClient);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientsList = await repository.GetAllAsync();

        return StatusCode(200, clientsList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var existingClient = await repository.GetAsync(id);

        return StatusCode(200, existingClient);
    }
}
