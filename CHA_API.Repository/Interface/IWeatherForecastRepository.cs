using System.Collections.Generic;
using System.Threading.Tasks;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Repository
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecastResponseModel>> GetWeatherForecasts();
    }
}
