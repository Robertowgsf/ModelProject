using Microsoft.EntityFrameworkCore;
using ModelProject.Domain.Entities;

namespace ModelProject.Infra.Data
{
    public class TweetContext : DbContext
    {
        public TweetContext(DbContextOptions<TweetContext> options) : base(options) { }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
