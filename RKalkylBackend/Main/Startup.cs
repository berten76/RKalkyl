using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Meals.API;
using Controllers;
//using Controllers;

namespace Main
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", polisy =>
                {
                    polisy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            var c = Configuration.GetConnectionString("DefaultConnection");
            // services.AddAutoMapper(typeof(Application.Core.MappingProfiles).Assembly);



            services.AddMediatR(
                Assembly.GetExecutingAssembly());//,
                                                 // typeof(Meals.API.FoodItemsController).Assembly,
                                                 //typeof(Meals.Application.FoodItems.List.Handler).Assembly);
            services.AddControllerServices(Configuration);
            services.AddMealServices(Configuration);
            //services.AddMediatR(typeof(Startup).Assembly);

            var assembly = Assembly.GetAssembly(typeof(Meals.API.MealsController));

            services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(assembly));

           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Main", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Main v1"));
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
