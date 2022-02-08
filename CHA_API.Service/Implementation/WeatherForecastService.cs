using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Repository;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherforecastRepo;
        public WeatherForecastService(IWeatherForecastRepository weatherforecastRepo)
        {
            _weatherforecastRepo = weatherforecastRepo;
        }

        public async Task<List<WeatherForecastResponseModel>> GetWeatherForecasts()
        {
            try
            {
                return await _weatherforecastRepo.GetWeatherForecasts();
            }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "WeatherForecastService", "GetWeatherForecasts");
            }
        }
    }
}
