using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Weather;

namespace Infrastructure
{
    public class WeatherData : IWeatherData
    {
        public IEnumerable<Forecast> GetWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new Forecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        static string[] Summaries
        {
            get
            {
                return WeatherSummary.GetAll<WeatherSummary>().Select(x=>x.ToString()).ToArray();
            }
        }
    }
}
