using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MediatR;
using Meals.Persistence;
using Meals.Application.FoodItems;
using System.Reflection;
using Meals.Application.Core;
using Meals.Application;

namespace Meals.API
{
 
    public static class MealServiceExtensions
    {
        public static IServiceCollection AddMealServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddPersistenceService(config);
            services.AddApplicationServices();
            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("CorsPolicy", polisy =>
            //    {
            //        polisy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            //    });
            //});
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddMediatR(typeof(List.Handler).Assembly);
            return services;
        }
    }
}
