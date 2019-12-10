using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;
using ModelProject.Core.Interfaces.Services;
using ModelProject.Core.Interfaces.Repositories;

namespace ModelProject.Application.Services
{
    public class TweetService : ServiceBase<Tweet, TweetSelector>, ITweetService
    {
        public TweetService(ITweetRepository repository)
            : base(repository) { }
    }
}
