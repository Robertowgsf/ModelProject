using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;

namespace ModelProject.Core.Interfaces.Repositories
{
    public interface ITweetRepository : IRepositoryBase<Tweet, TweetSelector>
    {
    }
}
