using System.Linq.Expressions;
using API_Gatinos.Models.Persistence;
using API_Gatinos.Models.Repositories.GenericDBConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Gatinos.Models.Repositories.GenericDBConnection;

public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity>
    where TEntity : Entity<TKey>
{
    public readonly DatabaseContext databaseContext;
    public readonly DbSet<TEntity> entitySet;

    public GenericRepository(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
        entitySet = databaseContext.Set<TEntity>();
    }

    public TEntity? GetById(TKey id) => entitySet.Find(id);

    public IEnumerable<TEntity>? GetByIds(IEnumerable<TKey> ids) =>
        GetAll().Where(x => ids.Contains(x.Id)).ToList();

    public IQueryable<TEntity> GetAll() => entitySet;

    public TEntity Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var addedEntity = databaseContext.Set<TEntity>().Add(entity).Entity;
        databaseContext.SaveChanges();
        return addedEntity;
    }

    public IEnumerable<TEntity>? Add(IEnumerable<TEntity> entities)
    {
        if (entities.Where(x => x == null).Any())
        {
            throw new ArgumentException(
                "One or more entities in the collection appears to be null."
            );
        }

        if (entities.Any())
        {
            databaseContext.Set<TEntity>().AddRange(entities);
            databaseContext.SaveChanges();
            return entities;
        }

        return default;
    }

    public TEntity Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var updatedEntity = databaseContext.Set<TEntity>().Update(entity).Entity;
        databaseContext.SaveChanges();
        return updatedEntity;
    }

    public IEnumerable<TEntity>? Update(IEnumerable<TEntity> entities)
    {
        if (entities.Any())
        {
            databaseContext.Set<TEntity>().UpdateRange(entities);
            databaseContext.SaveChanges();
            return entities;
        }

        return default;
    }

    public TEntity? Delete(TKey id)
    {
        if (id is null)
            throw new ArgumentException("The id is null.");

        var entity = GetById(id);
        if (entity == null)
            return null;
        var deletedEntity = entitySet.Remove(entity).Entity;
        databaseContext.SaveChanges();
        return deletedEntity;
    }

    public IEnumerable<TEntity>? Delete(IEnumerable<TKey> ids)
    {
        var entities = GetByIds(ids);
        if (entities != null)
        {
            entitySet.RemoveRange(entities);
            databaseContext.SaveChanges();
            return entities;
        }
        else
            return null;
    }

    //Custom functions
    public IQueryable<TEntity> Where(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null
    ) =>
        include?.Invoke(databaseContext.Set<TEntity>().Where(predicate))
        ?? databaseContext.Set<TEntity>().Where(predicate);
}
