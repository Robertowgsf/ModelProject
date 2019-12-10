using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;
using ModelProject.Core.Interfaces.Services;
using ModelProject.Presentation.ViewModels;

namespace ModelProject.Presentation.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/tweet")]
    public class TweetController : ApiControllerBase<ITweetService, TweetViewModel, Tweet, TweetSelector>
    {
        public TweetController(ITweetService service, IMapper mapper)
            : base(service, mapper) { }
    }
}