using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Service
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecastResponseModel>> GetWeatherForecasts();
    }
}
