using ModelProject.Core.Entities;

namespace ModelProject.Presentation.ViewModels
{
    public class TweetViewModel : ViewModelBase
    {
        public User User { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
