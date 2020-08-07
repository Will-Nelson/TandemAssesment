using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository.Interface;
using TandemAssesment.Factory;
using TandemAssesment.Interface;

using StackExchange.Redis;
using TandemAssesment.Service;
using TandemAssesment.Model;
using Repository.Model;
using TandemAssesment.Validation;
using FluentValidation;


namespace TandemAssesment
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IRepository, Repository.Repository>();
            services.AddScoped<IRepositoryService, RepositoryService>(); 
            services.AddTransient<IClientUserFactory, ClientModelFactory>();
            services.AddTransient<IRepositoryUserFactory, RepositoryModelFactory>();
            services.AddTransient<IValidator<UserSaveModel>, UserValidation>();
            string serverEndPoint = String.Empty;
            serverEndPoint = Environment.GetEnvironmentVariable("REDISSERVER");
 
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = Environment.GetEnvironmentVariable("REDISSERVER");
                
            });
            
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Api", Version = "v1" }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Api"));

            ;
        }
    }
}
