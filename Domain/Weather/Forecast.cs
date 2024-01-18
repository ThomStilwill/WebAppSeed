using System;

namespace Domain.Weather
{
    public class Forecast
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public WeatherSummary Summary { get; set; }
    }
}
