using System.Text;
using System.Text.Json;
using Domain.Weather;
using FluentAssertions;
using Foundation.Helpers;

namespace Tests.Foundation.Helpers
{
    internal class EnumerationJsonConverterTests
    {
        [Test]
        public void DeserializeForecast()
        {
            // Arrange
            var forecast = new Forecast()
            {
                Date = DateOnly.MinValue,
                Id = 0,
                Summary = WeatherSummary.Hot,
                TemperatureC = 32
            };

            var json = """
                       {
                        'Summary': 'Hot'
                       }

                       """;
            
            var reader = new Utf8JsonReader(Encoding.ASCII.GetBytes(json));
            var converter = new EnumerationJsonConverter<WeatherSummary,string>();

            // Act
            WeatherSummary result = converter.Read(ref reader, typeof(Forecast), null );

            // Assert
            result.Display.Should().Be("Hot");
            
        }

        [Test]
        public void SerializeWeatherSummary()
        {
            var summary = WeatherSummary.Comfy;
            var converter = new EnumerationJsonConverter<WeatherSummary,string>();


            var writerOptions = new JsonWriterOptions
            {
                Indented = true
            };

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, writerOptions);

            var serializerOptions = new JsonSerializerOptions(){};
            converter.Write(writer, summary, serializerOptions);
            writer.Flush();

            var json = Encoding.UTF8.GetString(stream.ToArray());

            json.Should().NotBeEmpty();
        }
    }
}
