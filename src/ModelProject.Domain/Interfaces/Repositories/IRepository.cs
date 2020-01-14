using System.Collections.Generic;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;

namespace ModelProject.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        TEntity Get(long id);
        IList<TEntity> Get();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }

    public interface IRepository<TEntity, TSelector> : IRepository<TEntity>
        where TEntity : EntityBase
        where TSelector : Selector
    {
        IList<TEntity> Get(TSelector selector);
    }
}
