using ModelProject.Core.Entities;
using ModelProject.Core.Interfaces.Repositories;
using ModelProject.Core.Selectors;
using System.Linq;

namespace ModelProject.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User, UserSelector>, IUserRepository
    {
        public UserRepository(TweetContext context) 
            : base(context) { }

        public override IQueryable<User> Parameters(IQueryable<User> query, UserSelector selector)
        {
            return query;
        }
    }
}
