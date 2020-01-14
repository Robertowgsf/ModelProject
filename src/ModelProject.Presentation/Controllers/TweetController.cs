using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Selectors;
using ModelProject.Domain.Interfaces.Services;
using ModelProject.Presentation.ViewModels;

namespace ModelProject.Presentation.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/tweet")]
    public class TweetController : ApiControllerBase<ITweetService, TweetViewModel, Tweet, Selector>
    {
        public TweetController(ITweetService service, IMapper mapper)
            : base(service, mapper) { }
    }
}