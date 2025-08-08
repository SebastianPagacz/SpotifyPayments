using MediatR;
using SpotifyPayment.Domain.Dtos;

namespace SpotifyPayments.Application.CQRS.Queries.ClientQueries;

public record GetAllClientsQuery : IRequest<List<ClientDto>> { }
