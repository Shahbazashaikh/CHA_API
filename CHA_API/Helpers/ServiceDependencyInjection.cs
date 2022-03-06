using Microsoft.Extensions.DependencyInjection;
using CHA_API.Service;

namespace CHA_API.Helpers
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection InjectServiceLayerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IConsigneeMasterService, ConsigneeMasterService>();
            services.AddScoped<IBuyerMasterServices, BuyerMasterService>();
            services.AddScoped<IClientMasterService, ClientMasterService>();
            services.AddScoped<IClientAddressMasterService, ClientAddressMasterService>();
            services.AddScoped<IClientDocumentMasterService, ClientDocumentMasterService>();

            return services;
        }
    }
}
