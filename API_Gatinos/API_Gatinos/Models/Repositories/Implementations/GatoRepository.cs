using API_Gatinos.Models.Entities;
using API_Gatinos.Models.Repositories.Interfaces;

namespace API_Gatinos.Models.Repositories.Implementations;

public class GatoRepository : IEntityRepository<Guid, Gato>
{
    public IQueryable<Gato> Get()
    {
        throw new NotImplementedException();
    }

    public Gato Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Gato Create(Gato entity)
    {
        throw new NotImplementedException();
    }

    public Gato Update(Gato entity)
    {
        throw new NotImplementedException();
    }

    public Gato Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
