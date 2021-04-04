using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Meals.Application.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Meals.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
