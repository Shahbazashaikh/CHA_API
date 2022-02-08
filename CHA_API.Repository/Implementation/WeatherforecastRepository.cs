using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using CHA_API.Model;
using CHA_API.Model.ResponseModel;

namespace CHA_API.Repository
{
    public class WeatherforecastRepository : IWeatherForecastRepository
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherforecastRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<List<WeatherForecastResponseModel>> GetWeatherForecasts()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecastResponseModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Email = _appSettings.Value.Email
            }).ToList();
            return await Task.FromResult(data);
        }
    }
}
