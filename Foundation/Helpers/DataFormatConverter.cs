using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Foundation.Helpers
{
    public class DateFormatConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateText = reader.GetString();
            return DateOnly.Parse(dateText);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            var isoDate = value.ToString("O");
            writer.WriteStringValue(isoDate);
        }
    }
}
