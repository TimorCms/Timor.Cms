using System;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using FluentValidation.AspNetCore;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Timor.Cms.Api;
using Timor.Cms.Api.Filters;
using Timor.Cms.Domains;
using Timor.Cms.Dto;
using Timor.Cms.Infrastructure;
using Timor.Cms.Infrastructure.Configuration;
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
                .AddControllersWithViews(options =>
                {
                    options.Filters.Add<ValidationFilter>();
                    options.Filters.Add<ExceptionFilter>();
                })
                .AddApplicationPart(typeof(ApiModule).Assembly)
                .AddControllersAsServices()
                .AddFluentValidation();

            services.AddHealthChecks();

            services.Configure<JwtOption>(Configuration.GetSection("JwtOption"));

            services.Configure<DbOption>(x=>
            {
                x.MongoConnectionString = Configuration.GetConnectionString("MongoDb");
                x.DataBase = Configuration.GetValue<string>("DbOption:DataBase");
            });

            var jwtOption = Configuration.GetSection("JwtOption").Get<JwtOption>();

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOption.SecurityKey)),

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = jwtOption.Issuer,

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = jwtOption.Audience,

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.FromSeconds(30)
                    };
                });

            services.AddAuthorization();

            services.AddLogging();

            services.AddCors();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Timor Cms Api Documents", Version = "v1" });
                IncludeXmlComments(config, typeof(DtoModule).Assembly);
                IncludeXmlComments(config, typeof(ApiModule).Assembly);

                config.AddSecurityDefinition("JwtToken",new OpenApiSecurityScheme
                {
                    Description = "通过Jwt Token进行授权,Token需要手动带上Bearer哦~",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
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
                typeof(DtoModule),
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(config =>
            {
                config.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

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
