using System.Linq.Expressions;

namespace ActividadUT2.Domain.Generic;

public interface IGenericRepository<in TKey, TEntity>
{
    IQueryable<TEntity> GetAll();
    TEntity? GetById(TKey id);
    IEnumerable<TEntity>? GetByIds(IEnumerable<TKey> ids);
    TEntity Add(TEntity entity);
    IEnumerable<TEntity>? Add(IEnumerable<TEntity> entities);
    TEntity Update(TEntity entity);
    IEnumerable<TEntity>? Update(IEnumerable<TEntity> entities);
    TEntity? Delete(TKey id);
    IEnumerable<TEntity>? Delete(IEnumerable<TKey> ids);

    //Extra functions
    IQueryable<TEntity> Where(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null
    );
}