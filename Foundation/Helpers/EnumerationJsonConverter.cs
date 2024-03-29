﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Foundation.Domain;

namespace Foundation.Helpers
{
    public class EnumerationJsonConverter<TEnum,TKey, TValue> : JsonConverter<TEnum> 
       where TEnum: Enumeration<TEnum,TKey,TValue>, new()
       where TKey: Enum
       where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var key = GenericConverter.ChangeType<TValue>(reader.GetString()!);
            var fromKey = Enumeration<TEnum, TKey, TValue>.FromValue(key);
            return fromKey;
        }
    
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
