using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelProject.Application.Services;
using ModelProject.Domain.Entities;
using ModelProject.Domain.Interfaces.Repositories;
using ModelProject.Domain.Interfaces.Services;
using ModelProject.Domain.Interfaces.UnitOfWork;
using ModelProject.Domain.Selectors;
using ModelProject.Infra.Data;
using ModelProject.Infra.Data.Repositories;
using ModelProject.Infra.Data.UoW;

namespace ModelProject.Infra.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Infra - Data.
            services.AddDbContext<TweetContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("TweetContext"));
            });
            services.AddScoped<IRepository<Tweet, Selector>, Repository<Tweet, Selector>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Application - Services.
            services.AddScoped<ITweetService, TweetService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
