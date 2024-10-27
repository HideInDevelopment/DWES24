using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Entities;
using AutoMapper;

namespace API_Gatinos.Models.Profiles;

public class ColoniaProfile : Profile
{
    public ColoniaProfile()
    {
        CreateMap<ColoniaDto, Colonia>()
            .ReverseMap()
            .ForMember(destino => destino.Id, origen => origen.MapFrom(source => source.Id))
            .ForMember(destino => destino.Nombre, origen => origen.MapFrom(source => source.Nombre))
            .ForMember(
                destino => destino.Ubicacion,
                origen => origen.MapFrom(source => source.Ubicacion)
            )
            .ForMember(
                destino => destino.Telefono,
                origen => origen.MapFrom(source => source.Telefono)
            )
            .ForMember(destino => destino.Movil, origen => origen.MapFrom(source => source.Movil))
            .ForMember(
                destino => destino.Descripcion,
                origen => origen.MapFrom(source => source.Descripcion)
            )
            .ForMember(destino => destino.Imagen, origen => origen.MapFrom(source => source.Imagen))
            .ForMember(destino => destino.Gatos, origen => origen.MapFrom(source => source.Gatos))
            .ForMember(
                destino => destino.Responsables,
                origen => origen.MapFrom(source => source.Responsables)
            );
    }
}
