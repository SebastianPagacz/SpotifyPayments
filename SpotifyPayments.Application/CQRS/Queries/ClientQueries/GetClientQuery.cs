using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Queries.ClientQueries;

public record GetClientQuery : IRequest<ClientDto>
{
    public int Id { get; set; }
}
