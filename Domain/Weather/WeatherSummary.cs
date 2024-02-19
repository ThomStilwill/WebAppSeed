using Foundation.Domain;

namespace Domain.Weather
{
    public class WeatherSummary : Enumeration<string>
    {
        public static WeatherSummary Chilly = new(nameof(Chilly));
        public static WeatherSummary Warm = new(nameof(Warm));
        public static WeatherSummary Hot = new(nameof(Hot));
        public static WeatherSummary Comfy = new(nameof(Comfy));

        public WeatherSummary() { }

        public WeatherSummary(string key, string display): base(key, display) { }
        public WeatherSummary(string display) : base(display, display) { }
    }
}
