using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Controllers
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(BaseApiController).Assembly);
            return services;
        }
    }
}
