using System.Collections.Generic;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;

namespace ModelProject.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        TEntity Get(long id);
        IList<TEntity> Get();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }

    public interface IRepositoryBase<TEntity, TSelector> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
        where TSelector : SelectorBase
    {
        IList<TEntity> Get(TSelector selector);
    }
}
