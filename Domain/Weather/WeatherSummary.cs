using Foundation.Domain;

namespace Domain.Weather
{
    public class WeatherSummary : Enumeration
    {
        private static int index = 0;

        public static WeatherSummary Freezing = new(index++, nameof(Freezing));
        public static WeatherSummary Bracing = new(index++, nameof(Bracing));
        public static WeatherSummary Chilly = new(index++, nameof(Chilly));
        public static WeatherSummary Cool = new(index++, nameof(Cool));
        public static WeatherSummary Mild = new(index++, nameof(Mild));
        public static WeatherSummary Warm = new(index++, nameof(Warm));
        public static WeatherSummary Balmy = new(index++, nameof(Balmy));
        public static WeatherSummary Hot = new(index++, nameof(Hot));
        public static WeatherSummary Sweltering = new(index++, nameof(Sweltering));
        public static WeatherSummary Scorching = new(index++, nameof(Scorching));

        public WeatherSummary() { }

        public WeatherSummary(int value, string displayName): base(value, displayName) { }
    }
}
