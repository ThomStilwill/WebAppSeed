using System.Text;
using System.Text.Json;
using Domain.Weather;
using FluentAssertions;
using Foundation.Helpers;

namespace Tests.Foundation.Helpers
{
    internal class EnumerationJsonConverterTests
    {

        /*
                [Test]
                public void DeserializeWeatherSummary()
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

                [Test]
                public void ConvertWeatherSummary()
                {
                    var summary = WeatherSummary.Comfy;
                    var converter = new EnumerationJsonConverter<WeatherSummary, string>();


                    var writerOptions = new JsonWriterOptions
                    {
                        Indented = true
                    };

                    using var stream = new MemoryStream();
                    using var writer = new Utf8JsonWriter(stream, writerOptions);

                    var serializerOptions = new JsonSerializerOptions() { };
                    converter.Write(writer, summary, serializerOptions);
                    writer.Flush();

                    var json = Encoding.UTF8.GetString(stream.ToArray());

                    json.Should().NotBeEmpty();
                }


                [Test]
                public void SerializeForecast()
                {
                    var summary = WeatherSummary.Comfy;
                    var converter = new EnumerationJsonConverter<WeatherSummary, string>();

                    var forecast = new Forecast()
                    {
                        Date = DateOnly.MinValue,
                        Id = 0,
                        Summary = WeatherSummary.Hot,
                        TemperatureC = 32
                    };

                    JsonSerializerOptions options = new();
                    options.Converters.Add(new EnumerationJsonConverter<WeatherSummary,string>());
                    options.WriteIndented = true;

                    var actual = JsonSerializer.Serialize(forecast, options);
                    Console.Write(actual);
                    actual.Should().NotBeEmpty();
                }

                [Test]
                public void DeserializeForecast()
                {
                    var json = """{ "Id":0, "Date":"0001-01-01", "TemperatureC":32, "TemperatureF":89, "Summary":"Hot" }""";
                    var converter = new EnumerationJsonConverter<WeatherSummary, string>();

                    JsonSerializerOptions options = new();
                    options.Converters.Add(new EnumerationJsonConverter<WeatherSummary,string>());

                    var actual = JsonSerializer.Deserialize<Forecast>(json, options);

                    actual.Should().NotBeNull();
                }
            }
        */
    }
}