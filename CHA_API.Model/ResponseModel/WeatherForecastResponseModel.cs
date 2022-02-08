using System;

namespace CHA_API.Model.ResponseModel
{
    public class WeatherForecastResponseModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public string Email { get; set; }
    }
}
