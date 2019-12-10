using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelProject.Application.Services;
using ModelProject.Core.Interfaces.Repositories;
using ModelProject.Core.Interfaces.Services;
using ModelProject.Infra.Data;
using ModelProject.Infra.Data.Repositories;


namespace ModelProject.Infra.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Context.
            services.AddDbContext<TweetContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("TweetContext"));
            });

            // Repositories.
            services.AddScoped<ITweetRepository, TweetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services.
            services.AddScoped<ITweetService, TweetService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
