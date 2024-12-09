namespace ActividadUT2.Domain.Generic;

public interface IEntityRepository<TKey, TEntity>
{
    IQueryable<TEntity> Get();
    TEntity? Get(TKey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(TEntity entity);
    TEntity? Delete(TKey id);
}