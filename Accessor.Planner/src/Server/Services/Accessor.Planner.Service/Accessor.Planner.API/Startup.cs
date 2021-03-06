using Accessor.Planner.API.Constants.Application;
using Accessor.Planner.Domain.Data;
using Accessor.Planner.Domain.Data.Repository;
using Accessor.Planner.Domain.Interface;
using Accessor.Planner.Domain.Service;
using Accessor.Planner.Infrastructure.Data;
using Accessor.Planner.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Proxy;
using Proxy.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accessor.Planner.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Accessor.Planner.API", Version = "v1" });
            });

            services.AddCors(option =>
            {
                option.AddPolicy(ApplicationConstants.Security.CorsPolicy,
                    builder => builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod());
            });

            services.AddCors();


            services.AddDbContext<ApplicationDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            DataInject(services);
            ServicesInject(services);
            IntegrationInject(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Accessor.Planner.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(ApplicationConstants.Security.CorsPolicy);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        public void DataInject(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<ISolicitationRepository, SolicitationRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

        }

        public void ServicesInject(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<ISolicitationService, SolicitationService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IIntegrationService, IntegrationService>();
        }

        public void IntegrationInject(IServiceCollection services)
        {
            var proxySettings = new ProxySettings();
            Configuration.GetSection(nameof(ProxySettings)).Bind(proxySettings);

            var application = new ProxyApplication(proxySettings);

            services.AddSingleton<IProxyApplication>(application);
        }
    }
}
