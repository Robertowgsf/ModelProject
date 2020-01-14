using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;

namespace ModelProject.Domain.Interfaces.Services
{
    public interface ITweetService : IServiceBase<Tweet, Selector>
    {
    }
}
