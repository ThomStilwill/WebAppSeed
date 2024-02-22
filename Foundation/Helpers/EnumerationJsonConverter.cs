using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Foundation.Domain;

namespace Foundation.Helpers
{
    public class EnumerationJsonConverter<TEnum,TKey>: JsonConverter<TEnum> 
       where TEnum: Enumeration<TEnum,TKey>, new()
       where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var key = GenericConverter.ChangeType<TKey>(reader.GetString()!);
            var fromKey = Enumeration<TEnum, TKey>.FromKey(key);
            return fromKey;
        }
    
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
