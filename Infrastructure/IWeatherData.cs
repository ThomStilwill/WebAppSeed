﻿using Domain.Weather;

namespace Infrastructure
{
    public interface IWeatherData
    {
        IEnumerable<Forecast> GetWeather();
    }
}