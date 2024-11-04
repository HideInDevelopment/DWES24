using API_Gatinos.Models.Entities;
using API_Gatinos.Models.Repositories.GenericDBConnection;
using API_Gatinos.Models.Repositories.Interfaces;

namespace API_Gatinos.Models.Repositories.Implementations;

public class ColoniaRepository : IEntityRepository<Guid, Colonia>
{
    private readonly IGenericRepository<Guid, Colonia> _repository;

    public ColoniaRepository(IGenericRepository<Guid, Colonia> repository)
    {
        _repository = repository;
    }

    public IQueryable<Colonia> Get() => _repository.GetAll();

    public Colonia? Get(Guid id) => _repository.GetById(id);

    public Colonia Create(Colonia entity) => _repository.Add(entity);

    public Colonia Update(Colonia entity) => _repository.Update(entity);

    public Colonia? Delete(Guid id) => _repository.Delete(id);
}
