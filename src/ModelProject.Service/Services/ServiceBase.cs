﻿using System.Collections.Generic;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;
using ModelProject.Core.Interfaces.Services;
using ModelProject.Core.Interfaces.Repositories;

namespace ModelProject.Application.Services
{
    public abstract class ServiceBase<TEntity, TSelector> : IServiceBase<TEntity, TSelector>
        where TEntity : EntityBase
        where TSelector : SelectorBase
    {
        protected readonly IRepositoryBase<TEntity, TSelector> _repository;

        public ServiceBase(IRepositoryBase<TEntity, TSelector> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Get(long id)
        {
            return _repository.Get(id);
        }
        
        public virtual IList<TEntity> Get(TSelector selector)
        {
            return _repository.Get(selector);
        }

        public virtual IList<TEntity> Get()
        {
            return _repository.Get();
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }
    }
}
