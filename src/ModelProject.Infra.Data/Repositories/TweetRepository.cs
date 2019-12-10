using ModelProject.Core.Interfaces.Repositories;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;
using System.Linq;

namespace ModelProject.Infra.Data.Repositories
{
    public class TweetRepository : RepositoryBase<Tweet, TweetSelector>, ITweetRepository
    {
        public TweetRepository(TweetContext context)
            : base(context) { }

        public override IQueryable<Tweet> Parameters(IQueryable<Tweet> query, TweetSelector selector)
        {
            return query;
        }
    }
}
