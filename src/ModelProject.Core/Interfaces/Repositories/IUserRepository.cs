using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;

namespace ModelProject.Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, UserSelector>
    {
    }
}
