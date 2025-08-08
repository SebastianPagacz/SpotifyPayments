using AutoMapper;
using SpotifyPayment.Domain.Dtos;
using SpotifyPayment.Domain.Models;

namespace SpotifyPayment.Domain.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClientModel, ClientDto>();
        CreateMap<PaymentModel, PaymentDto>();
        CreateMap<BalanceModel, BalanceDto>();
    }
}
