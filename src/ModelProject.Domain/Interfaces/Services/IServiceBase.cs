using System.Collections.Generic;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;

namespace ModelProject.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, TSelector>
        where TEntity : EntityBase
        where TSelector : Selector
    {
        TEntity Get(long id);
        IList<TEntity> Get(TSelector selector);
        IList<TEntity> Get();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
