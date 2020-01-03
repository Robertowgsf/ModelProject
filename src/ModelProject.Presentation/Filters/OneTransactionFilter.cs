using Microsoft.AspNetCore.Mvc.Filters;
using ModelProject.Core.Interfaces.UnitOfWork;

namespace ModelProject.Presentation.Filters
{
    public class OneTransactionFilter : IActionFilter
    {
        private readonly IUnitOfWork _uow;

        public OneTransactionFilter(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _uow.StartTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _uow.Rollback();
            }
            else
            {
                _uow.Commit();
            }
        }
    }
}
