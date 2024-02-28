using System.Security.Cryptography;
using Foundation.Domain;

namespace Domain.Weather
{
    public class WeatherSummary : Enumeration<WeatherSummary,WeatherSummary.Keys, string>
    {
        public enum Keys
        {
            Freezing,
            Cold,
            Chilly,
            Comfy,
            Warm,
            Hot,
            SATX
        }


        public static WeatherSummary Freezing = new(Keys.Freezing);
        public static WeatherSummary Cold = new(Keys.Cold);
        public static WeatherSummary Chilly = new(Keys.Chilly);
        public static WeatherSummary Comfy = new(Keys.Comfy);
        public static WeatherSummary Warm = new(Keys.Warm);
        public static WeatherSummary Hot = new(Keys.Hot);
        public static WeatherSummary SATX = new(Keys.SATX);

        public WeatherSummary() { }

        public WeatherSummary(Keys key) : base(key) { }
        public WeatherSummary(Keys key, string value) : base(key, value) { }
        public WeatherSummary(Keys key, string value, string display): base(key, value, display) { }
        
    }
}
