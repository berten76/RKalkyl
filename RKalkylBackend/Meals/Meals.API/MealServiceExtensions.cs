using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//using Persistance;
using MediatR;
using Meals.Persistence;

namespace Meals.API
{
 
    public static class MealServiceExtensions
    {
        public static IServiceCollection AddMealServices(this IServiceCollection services, IConfiguration config)
        {

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            //});
            services.AddPersistenceService(config);
        
            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("CorsPolicy", polisy =>
            //    {
            //        polisy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            //    });
            //});
          //  services.AddMediatR(typeof(List.Handler).Assembly);
          //  services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
    }
}
