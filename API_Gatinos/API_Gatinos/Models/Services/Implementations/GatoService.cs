using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Services.Interfaces;

namespace API_Gatinos.Models.Services.Implementations;

public class GatoService : IEntityService<Guid, GatoDTO>
{
    public GatoDTO Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public ICollection<GatoDTO> Get()
    {
        throw new NotImplementedException();
    }

    public GatoDTO Update(GatoDTO entity)
    {
        throw new NotImplementedException();
    }

    public GatoDTO Create(GatoDTO entity)
    {
        throw new NotImplementedException();
    }

    public GatoDTO Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
