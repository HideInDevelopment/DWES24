﻿namespace API_Gatinos.Models.Repositories.Interfaces;

public interface IEntityService<TKey, TEntity>
{
    ICollection<TEntity> Get();
    TEntity Get(TKey id);
    TEntity Create(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TKey id);
}