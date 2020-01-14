using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;
using ModelProject.Domain.Interfaces.Services;
using ModelProject.Domain.Interfaces.Repositories;

namespace ModelProject.Application.Services
{
    public class TweetService : ServiceBase<Tweet, Selector>, ITweetService
    {
        public TweetService(IRepository<Tweet, Selector> repository)
            : base(repository) { }
    }
}