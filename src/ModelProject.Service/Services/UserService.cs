using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;
using ModelProject.Domain.Interfaces.Services;
using ModelProject.Domain.Interfaces.Repositories;

namespace ModelProject.Application.Services
{
    public class UserService : ServiceBase<User, UserSelector>, IUserService
    {
        public UserService(IUserRepository repository)
            : base(repository) { }
    }
}
