using System;
using Foundation.Application.Abstractions;

namespace Domain.Weather
{
    public class Forecast : Entity
    {
        
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public WeatherSummary Summary { get; set; }
    }
}
