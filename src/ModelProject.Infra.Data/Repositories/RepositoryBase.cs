using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ModelProject.Core.Interfaces.Repositories;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;

namespace ModelProject.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly TweetContext _context;

        public RepositoryBase(TweetContext context)
        {
            _context = context;
        }

        public TEntity Get(long id)
        {
            return CreateQuery().SingleOrDefault(a => a.Id == id);
        }

        public IList<TEntity> Get()
        {
            IQueryable<TEntity> query = CreateQuery();

            var entityList = query.ToList();

            return entityList;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual IQueryable<TEntity> CreateQuery()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
    }

    public abstract class RepositoryBase<TEntity, TSelector> : RepositoryBase<TEntity>, IRepositoryBase<TEntity, TSelector>
        where TEntity : EntityBase
        where TSelector : SelectorBase
    {
        public RepositoryBase(TweetContext context)
            : base(context) { }

        public IList<TEntity> Get(TSelector selector)
        {
            IQueryable<TEntity> query = CreateQuery();

            query = Parameters(query, selector);
            query = Paginate(query, selector);
            query = Order(query);

            return query.ToList();
        }

        public abstract IQueryable<TEntity> Parameters(IQueryable<TEntity> query, TSelector selector);

        public IQueryable<TEntity> Paginate(IQueryable<TEntity> query, TSelector selector)
        {
            if (!selector.RowsPerPage.HasValue)
                return query;

            if (selector.Page < 1)
                selector.Page = 1;

            int amountToSkip = (selector.Page - 1) * selector.RowsPerPage.Value;

            return query.Skip(amountToSkip).Take(selector.RowsPerPage.Value);
        }

        public IQueryable<TEntity> Order(IQueryable<TEntity> query)
        {
            return query.OrderByDescending(a => a.Id);
        }
    }
}
