using API_Gatinos.Models.Entities;
using API_Gatinos.Models.Repositories.Interfaces;

namespace API_Gatinos.Models.Repositories.Implementations;

public class ColaboradorRepository : IEntityRepository<Guid, Colaborador>
{
    public IQueryable<Colaborador> Get()
    {
        throw new NotImplementedException();
    }

    public Colaborador Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Colaborador Create(Colaborador entity)
    {
        throw new NotImplementedException();
    }

    public Colaborador Update(Colaborador entity)
    {
        throw new NotImplementedException();
    }

    public Colaborador Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
