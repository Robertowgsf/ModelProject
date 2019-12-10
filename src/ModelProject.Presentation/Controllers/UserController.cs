using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelProject.Core.Interfaces.Services;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;
using ModelProject.Presentation.ViewModels;

namespace ModelProject.Presentation.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : ApiControllerBase<IUserService, UserViewModel, User, UserSelector>
    {
        public UserController(IUserService service, IMapper mapper)
            : base(service, mapper) { }
    }
}