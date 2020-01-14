using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelProject.Domain.Interfaces.Services;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;
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