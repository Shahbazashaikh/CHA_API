using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using CHA_API.Extensions;
using CHA_API.Helpers;
using CHA_API.Model;
using CHA_API.Repository;
using CHA_API.Service;
using CHA_API.Middleware;

namespace CHA_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
             .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpClient();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<AppSettings>(con => Configuration.GetSection("AppSettings").Bind(con));
            services.AddSwaggerGen();
            services.AddCors(option =>
            {
                option.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    return BadRequestCustomResponse.BadRequestResponse(actionContext);
                };
            });
            services.AddTokenAuthentication(Configuration.GetSection("AppSettings:JwtTokenSettings"));

            //Logger service
            services.AddSingleton(Log.Logger);

            // Repository Layer Dependencies
            services.AddScoped<IWeatherForecastRepository, WeatherforecastRepository>();

            // Service Layer Dependencies
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "CHA_API");
            });
            app.UseCors(option => option.AllowAnyOrigin());
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>(logger);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
