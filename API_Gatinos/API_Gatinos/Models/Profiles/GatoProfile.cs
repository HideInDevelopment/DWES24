using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Entities;
using AutoMapper;

namespace API_Gatinos.Models.Profiles;

public class GatoProfile : Profile
{
    public GatoProfile()
    {
        CreateMap<GatoDTO, Gato>()
            .ReverseMap()
            .ForMember(destino => destino.Id, origen => origen.MapFrom(source => source.Id))
            .ForMember(destino => destino.Nombre, origen => origen.MapFrom(source => source.Nombre))
            .ForMember(destino => destino.Edad, origen => origen.MapFrom(source => source.Edad))
            .ForMember(destino => destino.Raza, origen => origen.MapFrom(source => source.Raza))
            .ForMember(destino => destino.Peso, origen => origen.MapFrom(source => source.Peso))
            .ForMember(
                destino => destino.IdColonia,
                origen => origen.MapFrom(source => source.IdColonia)
            );
    }
}
