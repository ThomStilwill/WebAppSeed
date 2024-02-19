using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Foundation.Domain;

namespace Foundation.Helpers
{
    public class EnumerationJsonConverter<T,TKey> : JsonConverter<T> where T : Enumeration<TKey>, new() 
                                                                     where TKey : IComparable
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var key = GenericConverter.ChangeType<TKey>(reader.GetString()!);
            return Enumeration<TKey>.FromKey<T>(key);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        
    }

}
