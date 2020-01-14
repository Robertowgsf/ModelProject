using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;

namespace ModelProject.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, UserSelector>
    {
    }
}
