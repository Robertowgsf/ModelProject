using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ModelProject.Domain.Interfaces.Repositories;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;

namespace ModelProject.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly TweetContext _context;

        public Repository(TweetContext context)
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

    public class Repository<TEntity, TSelector> : Repository<TEntity>, IRepository<TEntity, TSelector>
        where TEntity : EntityBase
        where TSelector : Selector
    {
        public Repository(TweetContext context)
            : base(context) { }

        public IList<TEntity> Get(TSelector selector)
        {
            IQueryable<TEntity> query = CreateQuery();

            query = Parameters(query, selector);
            query = Paginate(query, selector);
            query = Order(query);

            return query.ToList();
        }

        public virtual IQueryable<TEntity> Parameters(IQueryable<TEntity> query, TSelector selector)
        {
            return query;
        }

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
