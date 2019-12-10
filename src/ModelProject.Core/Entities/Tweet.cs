namespace ModelProject.Core.Entities
{
    public class Tweet : EntityBase
    {
        public User User { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
