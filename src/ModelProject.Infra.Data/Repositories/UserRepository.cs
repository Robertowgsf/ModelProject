using ModelProject.Domain.Entities;
using ModelProject.Domain.Interfaces.Repositories;
using ModelProject.Domain.Selectors;
using System.Linq;

namespace ModelProject.Infra.Data.Repositories
{
    public class UserRepository : Repository<User, UserSelector>, IUserRepository
    {
        public UserRepository(TweetContext context) 
            : base(context) { }

        public override IQueryable<User> Parameters(IQueryable<User> query, UserSelector selector)
        {
            return query;
        }
    }
}
