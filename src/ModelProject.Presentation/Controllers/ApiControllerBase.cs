using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelProject.Domain.Interfaces.Services;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;
using ModelProject.Presentation.ViewModels;

namespace ModelProject.Presentation.Controllers
{
    public abstract class ApiControllerBase<TService, TViewModel, TEntity, TSelector> : Controller
        where TService : IServiceBase<TEntity, TSelector>
        where TViewModel : ViewModelBase
        where TEntity : EntityBase
        where TSelector : Selector
    {
        private readonly TService _service;
        private readonly IMapper _mapper;

        protected ApiControllerBase(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/[controller]/{id}
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id);

                if (entity == null)
                {
                    return NotFound();
                }

                var viewModel = _mapper.Map<TEntity, TViewModel>(entity);

                return Ok(viewModel);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                // TODO: Tratar exception.
            }
        }

        // GET: api/[controller]/selector
        [HttpGet]
        public ActionResult Get([FromRoute] TSelector selector)
        {
            try
            {
                var entities = _service.Get(selector);
                var viewModels = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(entities);

                return Ok(viewModels);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                // TODO: Tratar exception.
            }
        }

        // GET: api/[Controller]/
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var entities = _service.Get();
                var viewModels = _mapper.Map<IList<TEntity>, IList<TViewModel>>(entities);

                return Ok(viewModels);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                // TODO: Tratar exception.
            }
        }

        // POST: api/[Controller]
        [HttpPost]
        public ActionResult Add([FromBody]TViewModel viewModel)
        {
            try
            {
                var entity = _mapper.Map<TViewModel, TEntity>(viewModel);
                _service.Add(entity);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                // TODO: Tratar exception.
            }
        }

        // PUT: api/[Controller]
        [HttpPut]
        public ActionResult Update([FromBody]TViewModel viewModel)
        {
            try
            {
                var entity = _service.Get(viewModel.Id);
                _mapper.Map(viewModel, entity);
                _service.Update(entity);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                // TODO: Tratar exception.
            }
        }

        // DELETE: api/[Controller]/{id}
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            try
            {
                var entity = _service.Get(id);
                _service.Remove(entity);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                // TODO: Tratar exception.
            }
        }
    }
}
