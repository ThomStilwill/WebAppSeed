
using System.Collections.Generic;
using System.Linq;
using Domain.Weather;

namespace Application.Weather.Validators
{
    public class ForecastSettings
    {
        public IEnumerable<string> AvailableSummaries()
        {
            return WeatherSummary.GetAll()
                .Where(s => s!= WeatherSummary.Cold)
                .Select(x => x.Value);
        }
    }
}
