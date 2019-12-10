using System.Collections.Generic;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;

namespace ModelProject.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity, TSelector>
        where TEntity : EntityBase
        where TSelector : SelectorBase
    {
        TEntity Get(long id);
        IList<TEntity> Get(TSelector selector);
        IList<TEntity> Get();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
