using Foundation.Domain;

namespace Domain.Weather
{
    public class WeatherSummary : Enumeration<string>
    {
        public static WeatherSummary Chilly = new(nameof(Chilly));
        public static WeatherSummary Warm = new(nameof(Warm));
        public static WeatherSummary Hot = new(nameof(Hot));

        public WeatherSummary() { }

        public WeatherSummary(string value, string display): base(value, display) { }
        public WeatherSummary(string display) : base(display, display) { }
    }
}
