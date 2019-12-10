using ModelProject.Core.Entities;
using System.Collections.Generic;

namespace ModelProject.Presentation.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Tweet> Tweets { get; set; }
    }
}
