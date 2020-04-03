using System;
using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Timor.Cms.Api;
using Timor.Cms.Domains;
using Timor.Cms.Dto;
using Timor.Cms.Infrastructure;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Repository.MongoDb;
using Timor.Cms.Service;

namespace Timor.Cms.Web
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
            services.AddOptions();
            services
                .AddControllersWithViews()
                .AddApplicationPart(typeof(ApiModule).Assembly)
                .AddControllersAsServices();

            services.AddHealthChecks();

            services.AddCors();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Timor Cms Api Documents", Version = "v1" });
                IncludeXmlComments(config, typeof(DtoModule).Assembly);
                IncludeXmlComments(config, typeof(ApiModule).Assembly);
            });

        }

        private static void IncludeXmlComments(SwaggerGenOptions swaggerOption, Assembly assembly)
        {
            var apiXmlFile = $"{assembly.GetName().Name}.xml";
            var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
            swaggerOption.IncludeXmlComments(apiXmlPath);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            ModuleRegister.Regist(builder,
                typeof(InfrastructureModule),
                typeof(DomainModule),
                typeof(MongoDbRepositoryModule),
                typeof(ServiceModule),
                typeof(ApiModule),
                typeof(WebModule));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseSwagger(option => { option.SerializeAsV2 = true; });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHealthChecks("/health-check");

                endpoints.MapControllers();
            });

           
        }
    }
}
