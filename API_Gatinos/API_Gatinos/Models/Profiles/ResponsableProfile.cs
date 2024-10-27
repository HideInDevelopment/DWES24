using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Entities;
using AutoMapper;

namespace API_Gatinos.Models.Profiles;

public class ResponsableProfile : Profile
{
    public ResponsableProfile()
    {
        CreateMap<ResponsableDto, Responsable>()
            .ReverseMap()
            .ForMember(destino => destino.Id, origen => origen.MapFrom(source => source.Id))
            .ForMember(destino => destino.Nombre, origen => origen.MapFrom(source => source.Nombre))
            .ForMember(destino => destino.Edad, origen => origen.MapFrom(source => source.Edad))
            .ForMember(
                destino => destino.Telefono,
                origen => origen.MapFrom(source => source.Telefono)
            )
            .ForMember(destino => destino.Email, origen => origen.MapFrom(source => source.Email))
            .ForMember(
                destino => destino.Colonias,
                origen => origen.MapFrom(source => source.Colonias)
            );
    }
}
