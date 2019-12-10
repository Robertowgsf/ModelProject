using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;
using ModelProject.Core.Interfaces.Services;
using ModelProject.Core.Interfaces.Repositories;

namespace ModelProject.Application.Services
{
    public class UserService : ServiceBase<User, UserSelector>, IUserService
    {
        public UserService(IUserRepository repository)
            : base(repository) { }
    }
}
