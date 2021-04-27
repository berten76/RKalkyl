using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.API.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.API
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(BaseApiController).Assembly);
            return services;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExcpetionMiddleware>();
        }
    }
}
