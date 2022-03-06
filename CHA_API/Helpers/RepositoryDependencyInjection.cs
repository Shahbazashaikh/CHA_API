using Microsoft.Extensions.DependencyInjection;
using CHA_API.Repository;

namespace CHA_API.Helpers
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection InjectRepositoryLayerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastRepository, WeatherforecastRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IConsigneeRepository, ConsigneeRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IClientMasterRepository, ClientMasterRepository>();
            services.AddScoped<IClientAddressMasterRepository, ClientAddressMasterRepository>();
            services.AddScoped<IClientDocumentMasterRepository, ClientDocumentMasterRepository>();

            return services;
        }
    }
}
