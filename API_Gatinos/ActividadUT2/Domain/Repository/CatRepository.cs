using ActividadUT2.Domain.Entity;
using ActividadUT2.Domain.Generic;

namespace ActividadUT2.Domain.Repository;

public class CatRepository : IEntityRepository<Guid, Cat>
{
    private readonly IGenericRepository<Guid, Cat> _repository;

    public CatRepository(IGenericRepository<Guid, Cat> repository)
    {
        _repository = repository;
    }

    public IQueryable<Cat> Get() => _repository.GetAll();

    public Cat? Get(Guid id) => _repository.GetById(id);

    public Cat Create(Cat entity) => _repository.Add(entity);

    public Cat Update(Cat entity) => _repository.Update(entity);

    public Cat? Delete(Guid id) => _repository.Delete(id);
}