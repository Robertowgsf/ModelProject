﻿using ModelProject.Core.Entities;
using ModelProject.Core.Selectors;

namespace ModelProject.Core.Interfaces.Services
{
    public interface ITweetService : IServiceBase<Tweet, TweetSelector>
    {
    }
}
