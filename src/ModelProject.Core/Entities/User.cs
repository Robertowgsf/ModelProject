using System.Collections.Generic;

namespace ModelProject.Core.Entities
{
    public class User : EntityBase
    {
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Tweet> Tweets { get; set; }
    }
}
