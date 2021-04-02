using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;
//using Persistance;


namespace Meals.Persistence
{
    public static class PersistenceServiceExtensions
    {

        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MealsDataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            //  services.AddMediatR(typeof(List.Handler).Assembly);
            //  services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
    }
}

